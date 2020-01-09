using UnityEngine;

[RequireComponent(typeof(Hologram))]
public class BuildingPrototype : MonoBehaviour
{
    public static GameObject activePrototype;

    public LayerMask obstacleLayer;

    private Hologram _hologram;
    private bool _canPlace;
    private Vector2 _prevPos;


    private void Start()
    {
        obstacleLayer = LayerMask.GetMask("Obstacle", "Tower", "Road", "Building");
    }
    private void Update()
    {
        if (_prevPos != (Vector2)transform.position)
        {
            _canPlace = CheckForPlace();

            _hologram.spriteRenderer.color = _canPlace ?
                _hologram.hologramData.canBuildColor :
                _hologram.hologramData.cantBuildColor;
        }

        _prevPos = transform.position;
    }
    private void OnEnable()
    {
        Worktop.instance.onClick.AddListener(Build);
        if(_hologram == null)
        {
            _hologram = GetComponent<Hologram>();
        }
    }
    private void OnDisable()
    {
        Worktop.instance.onClick.RemoveListener(Build);
    }
    private void Build()
    {
        if(!_canPlace)
        {
            return;
        }

        GameObject b = Instantiate
            (PurchaseBuildingButton.gonnaPurchase.buildingPrefab,
            RoundedMousePosiiton.position,
            Quaternion.identity);
        Destroy(activePrototype);
    }

    protected virtual bool CheckForPlace()
    {
        bool canBuild = Physics2D.OverlapBoxAll
            (RoundedMousePosiiton.position,
            Vector2.one / 2, 0f,
            obstacleLayer).Length == 0;

        return canBuild;
    }
}
