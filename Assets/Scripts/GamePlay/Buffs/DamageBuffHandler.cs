using UnityEngine;

[RequireComponent(typeof(Attacking))]
public class DamageBuffHandler : MonoBehaviour, IBuffHandler
{
    private Attacking _attacking;
    private float _defaultDamage;


    private void Start()
    {
        _attacking = GetComponent<Attacking>();

        Buffs.onDamageChanged.AddListener(OnBuffModified);

        _defaultDamage = _attacking._damage;

        OnBuffModified();
    }

    public void OnBuffModified()
    {
        _attacking._damage = _defaultDamage + _defaultDamage * Buffs.Damage / 100f;
    }
}
