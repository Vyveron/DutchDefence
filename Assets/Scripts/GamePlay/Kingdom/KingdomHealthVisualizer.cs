using UnityEngine;

public class KingdomHealthVisualizer : MonoBehaviour
{
    public SpriteRenderer hpSprite;
    public Health kingdomHealth;

    private float _defautlWidth;

    private void Start()
    {
        _defautlWidth = hpSprite.size.x;
        kingdomHealth.onModified.AddListener((s) =>
        {
            Vector2 size = new Vector2
            (kingdomHealth.health / kingdomHealth.maxHealth * _defautlWidth,
            hpSprite.size.y);

            hpSprite.size = size;
        });  
    }
}
