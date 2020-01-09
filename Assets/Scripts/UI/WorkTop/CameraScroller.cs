using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraScroller : MonoBehaviour, IDragHandler, IScrollHandler
{
    public float sensitivity;
    public float scrollSensitivity;
    public float sizeChangeSpeed;
    public float minCamSize = 4f, maxCamSize = 20f;

    private Camera _cam;
    private float _desiredOrtographicSize;

    private void Start()
    {
        _cam = Camera.main;
        _desiredOrtographicSize = _cam.orthographicSize;
    }
    private void Update()
    {
        _cam.orthographicSize = Mathf.Lerp
            (_cam.orthographicSize,
            _desiredOrtographicSize,
            sizeChangeSpeed * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 delta = new Vector3(eventData.delta.x, eventData.delta.y, 0f) * sensitivity;
        _cam.transform.position += delta;
    }
    public void OnScroll(PointerEventData eventData)
    {
        _desiredOrtographicSize += scrollSensitivity * Input.GetAxisRaw("Mouse ScrollWheel");
        _desiredOrtographicSize = Mathf.Clamp(_desiredOrtographicSize, minCamSize, maxCamSize);
    }

}
