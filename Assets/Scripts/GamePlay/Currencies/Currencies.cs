using UnityEngine;
using UnityEngine.Events;

public class Currencies : MonoBehaviour
{
    public static UnityEvent onGoldChanged = new UnityEvent();
    public static int Gold { get; private set; }

    public int defaultGold = 1000;


    private void Start()
    {
        SetGold(defaultGold);
    }

    public static void AddGold(int value)
    {
        Gold = (int)Mathf.Max(0f, Gold + value);
        onGoldChanged.Invoke();
    }
    public static void SetGold(int value)
    {
        Gold = Mathf.Max(0, value);
        onGoldChanged.Invoke();
    }
}
