using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayerPanel : MonoBehaviour
{
    public Image previewField;
    public TextMeshProUGUI nameField;
    public TextMeshProUGUI timeField;
    public Image progressBarr;
    public MusicPlayer player;

    private float _timeSincePlay = 0f;
    private Song _currentSong;
    private float barDefaultWidth;


    private void Start()
    {
        player.onPlay.AddListener(() => { _timeSincePlay = 0f; });
        player.onPlay.AddListener(RefreshInfo);
        barDefaultWidth = progressBarr.rectTransform.rect.width;
    }
    private void Update()
    {
        if(_currentSong.clip == null)
        {
            return;
        }

        _timeSincePlay += Time.deltaTime;

        float percentage = Mathf.Clamp01(_timeSincePlay / _currentSong.clip.length);
        progressBarr.rectTransform.SetSizeWithCurrentAnchors
            (RectTransform.Axis.Horizontal,
            barDefaultWidth * percentage);
    }
    private void RefreshInfo()
    {
        _currentSong = player.GetCurrentSong();
        previewField.sprite = _currentSong.image;
        nameField.text = _currentSong.name;

        int minutes = (int)(_currentSong.clip.length / 60f);
        int seconds = (int)(_currentSong.clip.length - minutes * 60);
        timeField.text = minutes + ":" + seconds;
    }
}
