using UnityEngine;

[RequireComponent(typeof(Attacking))]
public class FireRateBuffHandler : MonoBehaviour, IBuffHandler
{
    private float _defaultAttackRate;
    private Attacking _attacking;


    private void Start()
    {
        _attacking = GetComponent<Attacking>();
        _defaultAttackRate = _attacking._damage;
        Buffs.onFireRateChanged.AddListener(OnBuffModified);

        OnBuffModified();
    }

    public void OnBuffModified()
    {
        _attacking._damage = _defaultAttackRate + _defaultAttackRate * Buffs.FireRate / 100f;
    }

}
