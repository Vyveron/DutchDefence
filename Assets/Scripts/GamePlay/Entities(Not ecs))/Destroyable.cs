using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Destroyable : MonoBehaviour
{
    public Health Health { get; private set; }

    private void Start()
    {
        Health = GetComponent<Health>();
        Health.onDied.AddListener(DestroyObject);
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}
