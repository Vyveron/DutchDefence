using UnityEngine;

public class Wallet : MonoBehaviour
{
    public void AddGold(int amount)
    {
        Currencies.AddGold(amount);
    }
}
