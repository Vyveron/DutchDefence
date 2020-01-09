using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public int price;

    public void Sell()
    {
        Currencies.AddGold(price);
        Destroy(gameObject);
        Selector.Deselect();
    }
}
