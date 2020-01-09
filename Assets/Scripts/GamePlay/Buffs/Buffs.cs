using UnityEngine.Events;
using UnityEngine;

public class Buffs : MonoBehaviour
{

    public static float Damage { get; private set; }
    public static float Health { get; private set; }
    public static float Range { get; private set; }
    public static float FireRate { get; private set; }

    public static UnityEvent onDamageChanged = new UnityEvent();
    public static UnityEvent onHealthChanged = new UnityEvent();
    public static UnityEvent onRangeChanged = new UnityEvent();
    public static UnityEvent onFireRateChanged = new UnityEvent();


    public void Start()
    {
        SetDamage(0);
        SetHealth(0);
        SetRange(0);
        SetFireRate(0);
    }

    public static void SetDamage(float value)
    {
        Damage = value;
        onDamageChanged.Invoke();
    }
    public static void SetHealth(float value)
    {
        Health = value;
        onHealthChanged.Invoke();
    }
    public static void SetRange(float value)
    {
        Range = value;
        onRangeChanged.Invoke();
    }
    public static void SetFireRate(float value)
    {
        FireRate = value;
        onFireRateChanged.Invoke();
    }

    public static void AddToDamage(float value)
    {
        Damage += value;
        onDamageChanged.Invoke();
    }
    public static void AddToHealth(float value)
    {
        Health += value;
        onHealthChanged.Invoke();
    }
    public static void AddToRange(float value)
    {
        FireRate += value;
        onRangeChanged.Invoke();
    }
    public static void AddToFireRate(float value)
    {
        FireRate += value;
        onFireRateChanged.Invoke();
    }
}
