using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : Mover, IChangeState
{
    public string animatorDirName;

    public float GetState()
    { 
        float value, dirAngle;

        dirAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) + Mathf.PI;
        value = dirAngle / (2f * Mathf.PI);

        return value;
    }
    public string GetParameterName()
    {
        return animatorDirName;
    }
}
