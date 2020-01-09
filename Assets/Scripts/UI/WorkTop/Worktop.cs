using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Worktop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static Worktop instance;

    public float maxClickRange = 0.1f;
    public UnityEvent onClick = new UnityEvent();
    public UnityEvent onMouseDown = new UnityEvent();
    public UnityEvent onMouseUp = new UnityEvent();

    private Vector2 onDownPos;


    private void Awake()
    {
        instance = this;

        onClick = new UnityEvent();
        onMouseDown = new UnityEvent();
        onMouseDown = new UnityEvent();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        onMouseDown.Invoke();

        onDownPos = eventData.position;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        onMouseUp.Invoke();

        if(Input.GetMouseButtonUp(0) &&
          (eventData.position - onDownPos).magnitude < maxClickRange)
        {
            onClick.Invoke();
        }
    }
}
