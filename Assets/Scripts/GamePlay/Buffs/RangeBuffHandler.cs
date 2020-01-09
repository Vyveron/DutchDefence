using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimHandler))]
public class RangeBuffHandler : MonoBehaviour, IBuffHandler
{
    private AimHandler _aimHandler;
    private float _defaultRange;


    private void Start()
    {
        _aimHandler = GetComponent<AimHandler>();

        Buffs.onRangeChanged.AddListener(OnBuffModified);
        _defaultRange = _aimHandler.Range;

        OnBuffModified();
    }

    public void OnBuffModified()
    {
        _aimHandler.Range = _defaultRange + _defaultRange * Buffs.Range / 100f;
    }
}
