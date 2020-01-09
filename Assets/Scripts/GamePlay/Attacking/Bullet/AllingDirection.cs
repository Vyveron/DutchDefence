using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AllingDirection : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private bool _shouldRefresh;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _shouldRefresh = true;
    }

    private void Update()
    {
        if (!_shouldRefresh)
            return;

        RefreshRotation(_rigidbody.velocity);
    }

    private void RefreshRotation(Vector2 dir)
    {
        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        Quaternion newRotation = Quaternion.Euler(0f, 0f, zAngle);

        transform.rotation = newRotation;
        _shouldRefresh = false;
    }
}