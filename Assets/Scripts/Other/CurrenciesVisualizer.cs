using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrenciesVisualizer : MonoBehaviour
{
    public TextMeshProUGUI goldField;

    private void Start()
    {
        Currencies.onGoldChanged.AddListener(() => 
        {
            goldField.text = Currencies.Gold.ToString() + "$";
        });
    }
}
