using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PathGenerator : MonoBehaviour
{
    public Transform end;

    [Header("Settings")]
    [Range(5, 99)] public int length = 20;
    [Range(5, 50)] public int step = 5;
    [Range(0, 99)] public int waveLenght = 5;
    public Vector2 offset;

    [Header("Visualization")]
    public PipelineTile pipelineTile;
    
    private Vector2Int endPos;
    private Vector2Int startPos;
    private List<Vector2Int> keyPoints = new List<Vector2Int>();
    private List<Vector2Int> points = new List<Vector2Int>();
    private List<Vector2> path = new List<Vector2>();


    private void GenerateKeypoints()
    {
        endPos = new Vector2Int((int)end.position.x, (int)end.position.y);
        startPos = endPos + Vector2Int.right * length;

        keyPoints.Add(endPos);

        for (int i = 5;
            i < length;
            i += Mathf.Min(Random.Range(3, step + 1), length - i))
        {
            int y = Random.Range(-waveLenght, waveLenght + 1);
            int x = i + endPos.x;

            Vector2Int newKeyPoint = new Vector2Int(x, y);
            Vector2Int corner = new Vector2Int(newKeyPoint.x, keyPoints[keyPoints.Count - 1].y);

            keyPoints.Add(corner);
            keyPoints.Add(newKeyPoint);
        }
    }
    private void GeneratePointsFromKeypoints()
    {
        for (int i = 0; i < keyPoints.Count - 1; i++)
        {
            Vector2Int current = keyPoints[i];
            Vector2Int next = keyPoints[i + 1];

            points.Add(current);

            int deltaX = next.x - current.x;
            int deltaY = next.y - current.y;

            if (deltaX == 0)
            {
                int absoluteDelta = Mathf.Abs(deltaY);

                for (int j = 1; j < absoluteDelta; j++)
                {
                    Vector2Int point = current + new Vector2Int(0, deltaY / absoluteDelta) * j;
                    points.Add(point);
                }
            }
            else if (deltaY == 0)
            {
                int absoluteDelta = Mathf.Abs(deltaX);

                for (int j = 1; j < absoluteDelta; j++)
                {
                    Vector2Int offset = new Vector2Int(deltaX / absoluteDelta, 0) * j;
                    Vector2Int point = current + offset;

                    points.Add(point);
                }
            }

        }

        points.Add(keyPoints[keyPoints.Count - 1]);
    }
    private void GeneratePoints()
    {
        GenerateKeypoints();
        GeneratePointsFromKeypoints();
    }
    private void VisualizePath()
    {
        for (int i = 0; i < points.Count; i++)
        {
            Vector3Int cellPos = RoadTilemap.tilemap.WorldToCell((Vector2)points[i]);
            RoadTilemap.tilemap.SetTile(new Vector3Int(points[i].x, points[i].y, 0), pipelineTile);
        }
    }
    private void CreatePathFromPoints()
    {
        for(int i = points.Count - 1; i >= 0; i--)
        {
            path.Add(points[i] + offset);
        }
    }
    private void TransferPath()
    {
        Path.SetPath(path);
    }
    private void Start()
    {
        GeneratePoints();
        CreatePathFromPoints();
        VisualizePath();
        TransferPath();
    }
    private void OnDrawGizmos()
    {
        if(Path.isCreated)
        {
            for(int i = 0; i < path.Count; i++)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(path[i], 0.1f);
            }
        }
    }
}
