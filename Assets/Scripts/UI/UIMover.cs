using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMover : MonoBehaviour
{
    public Side moveTo;
    public AnimationCurve appearCurve, disappearCurve;
    public float time;
    public Vector2 defaultPosition;

    private RectTransform _canvas;
    private RectTransform _rectTransform;
    private Coroutine _currentCoroutine;
    [SerializeField] private State _state;


    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<RectTransform>();
    }

    public void Hide()
    {
        if(_state == State.hidden)
        {
            return;
        }

        Vector2 desiredPos;
        float pivotKoef;
        float anchorKoef;
        float height = _rectTransform.rect.height;
        float width = _rectTransform.rect.width;

        switch(moveTo)
        {
            case Side.right:
                {
                    pivotKoef = _rectTransform.pivot.x;
                    anchorKoef = 1 - _rectTransform.anchorMin.x;

                    float x = _canvas.rect.width * anchorKoef + pivotKoef * width;
                    float y = _rectTransform.anchoredPosition.y;

                    desiredPos = new Vector2(x, y);

                    break;
                }
            case Side.top:
                {
                    pivotKoef = _rectTransform.pivot.y;
                    anchorKoef = 1 - _rectTransform.anchorMin.y;

                    float x = _rectTransform.anchoredPosition.y;
                    float y = _canvas.rect.height * anchorKoef + height * pivotKoef;

                    desiredPos = new Vector2(x, y);

                    break;
                }
            case Side.left:
                {
                    pivotKoef = 1 - _rectTransform.pivot.x;
                    anchorKoef = _rectTransform.anchorMin.x;

                    float x = -_canvas.rect.width * anchorKoef - width * pivotKoef;
                    float y = _rectTransform.anchoredPosition.y;

                    desiredPos = new Vector2(x, y);

                    break;
                }
            case Side.bottom:
                {
                    pivotKoef = 1 - _rectTransform.pivot.y;
                    anchorKoef = _rectTransform.anchorMin.y;

                    float y = -_canvas.rect.height * anchorKoef - height * pivotKoef;
                    float x = _rectTransform.anchoredPosition.x;

                    desiredPos = new Vector2(x, y);

                    break;
                }
            default: return;
        }

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = StartCoroutine(MoveTo(desiredPos, disappearCurve, time));
        _state = State.hidden;
    }
    public void Show()
    {
        if(_state == State.shown)
        {
            return;
        }

        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }
        _currentCoroutine = StartCoroutine(MoveTo(defaultPosition, appearCurve, time));
        _state = State.shown;
    }

    protected IEnumerator MoveTo(Vector2 destination, AnimationCurve curve, float time)
    {
        Vector2 startPoint = _rectTransform.anchoredPosition;

        for (float timePassed = 0f; timePassed <= time; timePassed += Time.deltaTime)
        {
            Vector2 deltaPos = (destination - startPoint) * curve.Evaluate(timePassed / time);
            _rectTransform.anchoredPosition = startPoint + deltaPos;
            yield return null;
        }
        _rectTransform.anchoredPosition = destination;
    }


    public enum Side
    {
        right,
        top,
        left,
        bottom
    }
    private enum State
    {
        hidden,
        shown
    }
}
