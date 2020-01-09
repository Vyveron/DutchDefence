using UnityEngine;

public abstract class TowerProfileHandler : MonoBehaviour, ISelectable
{
    public TowerData data;


    public void OnSelect()
    { 

    }
    public SelectedData GetData()
    {
        SelectedData info;
        TowerRepresentation representation;

        info.type = DataType.towerInfo;
        representation.lvl = data.lvl;
        representation.name = data.name;

        info.data = JsonUtility.ToJson(representation);

        return info;
    }
}
