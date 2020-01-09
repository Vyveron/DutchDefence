using UnityEngine;

[CreateAssetMenu(fileName = "New Hologram data", menuName = "TD/Building/New Hologram")]
public class HologramData : ScriptableObject
{
    public Sprite hologramSprite;
    public Color canBuildColor = new Color(0f, 1f, 0f, 0.75f);
    public Color cantBuildColor = new Color(1f, 0f, 0f, 0.75f);
    public BuildingData buildingData;
}
