using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo : MonoBehaviour, ISelectable
{
    public new string name;
    public int lvl;

    public void OnSelect()
    {

    }
    public SelectedData GetData()
    {
        throw new System.NotImplementedException();
    }
}

