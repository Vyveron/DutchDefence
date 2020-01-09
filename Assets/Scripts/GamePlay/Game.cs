using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public static UnityEvent onWin = new UnityEvent();
    public static UnityEvent onLose = new UnityEvent();
    
    private void Start()
    {
        WaveObserver.onWaveFinished.AddListener(Win);
    }

    public void Win()
    {
        onWin.Invoke();
    }
    public void Lose()
    {
        onLose.Invoke();
    }
}
