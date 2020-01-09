using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuffWriter : MonoBehaviour
{
    public TextMeshProUGUI damageBuffField;
    public TextMeshProUGUI healthBuffField;
    public TextMeshProUGUI rangeBuffFeild;
    public TextMeshProUGUI fireRateBuffField;

    private void Awake()
    {
        Buffs.onDamageChanged.AddListener(RefreshDamage);
        Buffs.onHealthChanged.AddListener(RefreshHealth);
        Buffs.onRangeChanged.AddListener(RefreshRange);
        Buffs.onFireRateChanged.AddListener(RefreshFireRate);
    }
    
    public void RefreshDamage()
    {
        damageBuffField.text = "Damage: " + Buffs.Damage.ToString();
    }
    public void RefreshHealth()
    {
        healthBuffField.text = "Health: " + Buffs.Health.ToString();
    }
    public void RefreshRange()
    {
        rangeBuffFeild.text = "Range: " + Buffs.Range.ToString();
    }
    public void RefreshFireRate()
    {
        fireRateBuffField.text = "Fire rate: " + Buffs.FireRate.ToString();
    }
}
