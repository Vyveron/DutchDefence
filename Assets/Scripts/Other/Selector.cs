using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Selector : MonoBehaviour
{
    public static SelectEvent onSelect = new SelectEvent();
    public static UnityEvent onDeselect = new UnityEvent();
    public static bool isSelected;
    public static GameObject selectedObj;

    public LayerMask rayLayer;

    private Camera _cam;
    private ISelectable[] _selectedComponents;


    public static void Refresh()
    {
        if(selectedObj == null)
        {
            isSelected = false;
        }
        else
        {
            isSelected = true;
        }
    }

    private void Start()
    {
        Worktop.instance.onClick.AddListener(ClickCallback);
        _cam = Camera.main;
    }

    private void ClickCallback()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit2D = Physics2D.GetRayIntersection(ray, Mathf.Infinity, rayLayer);

        if (hit2D.collider != null)
        {
            Select(hit2D);
        }
        else
        {
            Deselect();
        }
    }

    private void Select(RaycastHit2D hit2D)
    {
        _selectedComponents = hit2D.collider.gameObject.GetComponents<ISelectable>();

        if (_selectedComponents.Length == 0)
        {
            selectedObj = null;
            return;
        }

        selectedObj = hit2D.collider.gameObject;
        isSelected = true;

        for (int i = 0; i < _selectedComponents.Length; i++)
        {
            _selectedComponents[i].OnSelect();
            onSelect.Invoke(_selectedComponents[i].GetData());
        }

    }
    public static void Deselect()
    {
        onDeselect.Invoke();
        isSelected = false;
    }
    

    public class SelectEvent : UnityEvent<SelectedData> {}
}

public struct SelectedData
{
    public string data;
    public DataType type;
}
public enum DataType
{
    towerInfo
}