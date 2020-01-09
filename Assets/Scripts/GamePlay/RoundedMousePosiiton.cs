using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundedMousePosiiton : MonoBehaviour
{
    public static Vector2 position;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }

    private void Update()
    {
        position = _cam.ScreenToWorldPoint(Input.mousePosition);
        
        if (position.x > 0f)
        {
            position.x = (int)position.x + 0.5f;
        }
        else
        {
            position.x = (int)position.x - 0.5f;
        }

        if (position.y > 0f)
        {
            position.y = (int)position.y + 0.5f;
        }
        else
        {
            position.y = (int)position.y - 0.5f;
        }
    }
}
