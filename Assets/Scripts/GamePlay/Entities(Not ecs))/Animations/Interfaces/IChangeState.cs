using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangeState
{
    float GetState();
    string GetParameterName();
}