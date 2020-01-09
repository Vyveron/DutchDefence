using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Buff tower", menuName = "TD/Towers/New Buff tower")]
public class BuffTowerData : TowerData
{
    public float damageBuff;
    public float healthBuff;
    public float rangeBuff;
    public float fireRateBuff;
}
