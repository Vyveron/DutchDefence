using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRandomizer : MonoBehaviour
{
    public Vector2 yRange = new Vector2(-5f, 5f);
    public Vector2 xRange = new Vector2(-5f, 5f);

    private void Start()
    {
        float x = Random.Range(xRange.x, xRange.y);
        float y = Random.Range(yRange.x, yRange.y);

        transform.position += new Vector3(x, y, 0);
    }
}
