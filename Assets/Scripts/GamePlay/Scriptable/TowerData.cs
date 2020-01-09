using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TowerData : ScriptableObject
{
    public new string name;
    public int lvl;
}

[System.Serializable]
public struct TowerRepresentation
{
    public string name;
    public int lvl;
}