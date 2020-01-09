using UnityEngine;

[CreateAssetMenu(fileName = "New Building data", menuName = "TD/Building/New Building")]
public class BuildingData : ScriptableObject
{
    public GameObject buildingPrefab;
    public HologramData hologramData;
    public int price;
}
