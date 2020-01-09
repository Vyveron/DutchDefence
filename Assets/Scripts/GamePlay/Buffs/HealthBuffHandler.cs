using UnityEngine;

[RequireComponent(typeof(Health))]
public class HealthBuffHandler : MonoBehaviour, IBuffHandler
{
    private Health _healthComponent;
    private float _defaultHp;


    private void Start()
    {
        _healthComponent = GetComponent<Health>();

        _defaultHp = _healthComponent.maxHealth;
        Buffs.onHealthChanged.AddListener(OnBuffModified);

        OnBuffModified();
    }

    public virtual void OnBuffModified()
    {
        float hp = _healthComponent.health;
        float maxHp = _healthComponent.maxHealth;
        
        float newMaxHp = _defaultHp + _defaultHp * Buffs.Health / 100f;
        float newHp = hp / maxHp * newMaxHp;

        _healthComponent.maxHealth = newMaxHp;
        _healthComponent.health = newHp;
    }
}
