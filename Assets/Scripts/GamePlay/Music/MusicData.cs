using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Music preset", menuName = "TD/Music/New Music preset")]
public class MusicData : ScriptableObject
{
    public List<Song> music;
}

[System.Serializable]
public struct Song
{
    public AudioClip clip;
    public string name;
    public Sprite image;
}