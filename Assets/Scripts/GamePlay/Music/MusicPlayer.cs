using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    public AudioMixer mixer;
    public MusicData preset;
    public UnityEvent onFinishedPlaying = new UnityEvent();
    public UnityEvent onPlay = new UnityEvent();
    public float delayBetweenClips = 8f;

    private List<Song> _playlist;
    private AudioSource _source;
    private int currentSong = -1;


    private void Start()
    {
        _source = GetComponent<AudioSource>();

        _playlist = preset.music;
        _source.loop = false;
        onFinishedPlaying.AddListener(() => { Invoke("PlayNextInPlaylist", delayBetweenClips); });
        Invoke("PlayNextInPlaylist", delayBetweenClips);
    }

    public Song GetCurrentSong()
    {
        return _playlist[currentSong];
    }
    public void PlayNextInPlaylist()
    {
        StartCoroutine(PlayNext());
    }
    public IEnumerator PlayNext()
    {
        currentSong = Random.Range(0, _playlist.Count);
        _source.clip = _playlist[currentSong].clip;
        _source.Play();

        if(currentSong >= _playlist.Count)
        {
            currentSong = 0;
        }

        onPlay.Invoke();
        yield return new WaitForSeconds(_source.clip.length);
        onFinishedPlaying.Invoke();
    }
}
