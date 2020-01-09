using UnityEngine;

public class Upgrader : MonoBehaviour
{
    public GameObject nextLvl;
    public int price;

    public void Upgrade()
    {
        if(Currencies.Gold < price)
        {
            return;
        }

        Currencies.AddGold(-price);
        GameObject lvlUp = Instantiate(nextLvl, transform.position, transform.rotation);
        Destroy(gameObject);
        Selector.Deselect();
    }
}
