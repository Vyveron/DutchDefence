using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void Start()
    {
        Path.AddRequestOnCreate(() => { transform.position = Path.VectorPath[0]; });
    }
}
