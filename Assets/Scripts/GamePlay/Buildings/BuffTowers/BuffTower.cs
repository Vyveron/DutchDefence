using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuffTowerProfileHandler))]
public class BuffTower : MonoBehaviour
{
    private BuffTowerProfileHandler _profile;

    private void Start()
    {
        _profile = GetComponent<BuffTowerProfileHandler>();

        Buffs.AddToDamage(_profile.data.damageBuff);
        Buffs.AddToHealth(_profile.data.healthBuff);
        Buffs.AddToRange(_profile.data.rangeBuff);
        Buffs.AddToFireRate(_profile.data.fireRateBuff);
    }
    private void OnDestroy()
    {
        Buffs.AddToDamage(-_profile.data.damageBuff);
        Buffs.AddToHealth(-_profile.data.healthBuff);
        Buffs.AddToRange(-_profile.data.rangeBuff);
        Buffs.AddToFireRate(-_profile.data.fireRateBuff);
    }
}
