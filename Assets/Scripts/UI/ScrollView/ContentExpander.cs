using UnityEngine;
using UnityEngine.UI;

public class ContentExpander : MonoBehaviour
{
    [SerializeField] private RectTransform content;
    [SerializeField] private LayoutGroup desiredContentWidth;
    private float _prevWidth = 0f;
    private float _preferedWidth = 0f;

    private void Update()
    {
        _preferedWidth = desiredContentWidth.preferredWidth;

        if (_prevWidth != _preferedWidth)
        {
            content.sizeDelta = new Vector2(_preferedWidth, content.sizeDelta.y);
            _prevWidth = _preferedWidth;
        }
    }

}
