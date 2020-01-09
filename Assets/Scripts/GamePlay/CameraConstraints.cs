using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConstraints : MonoBehaviour
{
    public Transform minPositionRef, maxPositionRef;

    private Vector3 _minPosition, _maxPosition;
    private Camera _cam;

    private void Start()
    {
        _cam = Camera.main;
    }
    private void Update()
    {
        ClipCameraCoords();
    }

    private void ConvertConstraints()
    {
        Vector3 cornerDelta = new Vector3(_cam.orthographicSize * _cam.aspect, _cam.orthographicSize, 0f);

        _minPosition = minPositionRef.position + cornerDelta;
        _maxPosition = maxPositionRef.position - cornerDelta;
    }
    private void ClipCameraCoords()
    {
        ConvertConstraints();

        float clipedX = Mathf.Clamp(_cam.transform.position.x, _minPosition.x, _maxPosition.x);
        float clipedY = Mathf.Clamp(_cam.transform.position.y, _minPosition.y, _maxPosition.y);

        Vector3 clipedPos = new Vector3(clipedX, clipedY, _cam.transform.position.z);

        _cam.transform.position = clipedPos;
    }
}
