using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float health;
    public ModifyEvent onModified = new ModifyEvent();
    public UnityEvent onDied = new UnityEvent();

    private bool _isDead;

    protected virtual void Start()
    {
        health = maxHealth;
    }

    public virtual void Modify(float value = 0)
    {
        health += value;
        onModified.Invoke(value);

        if(health <= 0 && !_isDead)
        {
            _isDead = true;
            onDied.Invoke();
        }
    }

    public class ModifyEvent : UnityEvent<float> { }

}
