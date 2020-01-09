using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(UIMover))]
public class InfoPanel : MonoBehaviour
{
    public UIMover mover;
    public TextMeshProUGUI infoField;
    public TextMeshProUGUI upgradePriceField;
    public TextMeshProUGUI sellPriceField;
    public Button upgradeButton;
    public Button sellButton;

    private TowerRepresentation _info;


    private void Start()
    {
        mover = GetComponent<UIMover>();
        Selector.onSelect.AddListener(PresentData);
        Selector.onDeselect.AddListener(Hide);

        Currencies.onGoldChanged.AddListener(RefreshButtons);
    }
    private void RefreshButtons()
    {
        if (!Selector.isSelected)
        {
            return;
        }

        Upgrader upgrader = Selector.selectedObj.GetComponent<Upgrader>();
        Seller seller = Selector.selectedObj.GetComponent<Seller>();

        if (upgrader == null)
        {
            upgradeButton.interactable = false;
            upgradePriceField.text = "-";
        }
        else if (upgrader.price > Currencies.Gold)
        {
            upgradeButton.interactable = false;
            upgradePriceField.text = upgrader.price.ToString();
        }
        else
        {
            upgradeButton.interactable = true;
            upgradePriceField.text = "-" + upgrader.price.ToString();
        }

        if (seller == null)
        {
            sellButton.interactable = false;
            upgradePriceField.text = "-";
        }
        else
        {
            sellButton.interactable = true;
            sellPriceField.text = "+" + seller.price.ToString();
        }
    }

    public void PresentData(SelectedData data)
    {
        if(data.type != DataType.towerInfo)
        {
            return;
        }

        _info = JsonUtility.FromJson<TowerRepresentation>(data.data);

        infoField.text = _info.name + "\nlvl " + _info.lvl;
        RefreshButtons();

        Show();
    }
    public void Show()
    {
        mover.Show();
    }
    public void Hide()
    {
        mover.Hide();
    }
}