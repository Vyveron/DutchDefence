using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Pathfinder))]
public class Mover : MonoBehaviour
{
    public float speed;

    protected Rigidbody2D rb;
    protected Pathfinder pathfinder;


    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pathfinder = GetComponent<Pathfinder>();
    }
    protected virtual void FixedUpdate()
    {
        if (pathfinder._ReachedDestination)
        {
            rb.velocity = Vector2.zero;
        }
        else
        {
            Vector2 direction = (pathfinder.TargetPoint - rb.position).normalized;
            rb.velocity = direction * speed;
        }
    }
}
