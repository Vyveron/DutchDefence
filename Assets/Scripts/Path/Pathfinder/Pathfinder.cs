using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [Range(0f, 10f)] public float reachDistance = 0.1f;
    [Header("Randomization")]
    public Vector2 randomXRange;
    public Vector2 randomYRange;
    public Vector2 CurCell { get; private set; }
    public Vector2 TargetPoint { get; private set; }
    public bool _ReachedDestination { get; private set; } = false;

    private int _tartePointIndex = 0;
    private bool _startedPathfinding = false;
    private Vector2 randomVector;

    private void Start()
    {
        StartPathfinding();
        randomVector = new Vector2
            (Random.Range(randomXRange.x, randomXRange.y),
            Random.Range(randomYRange.x, randomYRange.y));
    }
    private void Update()
    {
        if (_ReachedDestination || !_startedPathfinding)
            return;

        bool shouldIncrement = CheckIfReached();
        if (shouldIncrement)
        {
            IncrementTarget();
            CheckIfReachedDestination();
        }
    }
    private void StartPathfinding()
    {
        if (Path.isCreated)
        {
            CurCell = transform.position;
            _tartePointIndex = 0;
            _ReachedDestination = false;
            TargetPoint = Path.VectorPath[_tartePointIndex];
            _startedPathfinding = true;
        }
        else
        {
            Path.AddRequestOnCreate(StartPathfinding);
        }
    }
    private void IncrementTarget()
    {
        CurCell = Path.VectorPath[_tartePointIndex];
        TargetPoint = Path.VectorPath[++_tartePointIndex] + randomVector;
    }
    private void CheckIfReachedDestination()
    {
        if (_tartePointIndex >= Path.VectorPath.Count - 1)
        {
            _ReachedDestination = true;
        }
    }
    private bool CheckIfReached()
    {
        bool reachedNext = false;
        float distance = ((Vector2)transform.position - TargetPoint).magnitude;

        if (distance <= reachDistance)
        {
            reachedNext = true;
        }

        return reachedNext;
    }
}
