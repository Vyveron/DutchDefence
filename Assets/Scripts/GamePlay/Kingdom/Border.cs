using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Border : MonoBehaviour
{
    public UnityEvent onEntered = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEntered.Invoke();
        Health health = collision.GetComponent<Health>();
        health.Modify(-99999);
    }
}
