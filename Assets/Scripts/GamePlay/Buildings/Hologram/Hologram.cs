using UnityEngine;

public class Hologram : MonoBehaviour
{
    public HologramData hologramData;
    public SpriteRenderer spriteRenderer;

    public static GameObject CreateHologram(HologramData data)
    {
        GameObject hologram = Instantiate(new GameObject("Hologram"));

        Hologram hologramComponent = hologram.AddComponent<Hologram>();
        BuildingPrototype buildingPrototypeComponent = hologram.AddComponent<BuildingPrototype>();
        SpriteRenderer spriteRenderer = hologram.AddComponent<SpriteRenderer>();

        spriteRenderer.sortingLayerName = "Buildings";
        spriteRenderer.sortingOrder = 100;
        spriteRenderer.sprite = data.hologramSprite;
        spriteRenderer.color = data.canBuildColor;

        hologramComponent.spriteRenderer = spriteRenderer;
        hologramComponent.hologramData = data;

        return hologram;
    }
}
