using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellUpgrade : MonoBehaviour
{
    public void Sell()
    {
        Seller seller = Selector.selectedObj.GetComponent<Seller>();

        seller.Sell();
    }
    public void Upgrade()
    {
        Upgrader upgrader = Selector.selectedObj.GetComponent<Upgrader>();

        upgrader.Upgrade();
    }
}
