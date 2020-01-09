using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PurchaseBuildingButton : MonoBehaviour
{
    public static BuildingData gonnaPurchase;

    public BuildingData building;
    public TextMeshProUGUI priceField;

    private Button _button;


    private void Start()
    {
        _button = GetComponent<Button>();

        Currencies.onGoldChanged.AddListener(RefreshButton);
        priceField.text = building.price.ToString() + "$";
    }
    private void RefreshButton()
    {
        if (Currencies.Gold >= building.price)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }
    }
    private void GiveHologram()
    {
        GameObject hologram = Hologram.CreateHologram(building.hologramData);
        BuildingPrototype.activePrototype = hologram;
        Hand.Give(hologram);
    }
    private void PurchaseBuilding()
    {
        Currencies.AddGold(-building.price);
        Worktop.instance.onClick.RemoveListener(PurchaseBuilding);
    }

    public void SelectBuilding()
    {
        Worktop.instance.onClick.RemoveListener(PurchaseBuilding);

        Destroy(BuildingPrototype.activePrototype);

        GiveHologram();
        gonnaPurchase = building;
        RefreshButton();

        Worktop.instance.onClick.AddListener(PurchaseBuilding);
    }
}
