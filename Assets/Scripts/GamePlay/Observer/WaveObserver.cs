using UnityEngine;
using UnityEngine.Events;

public class WaveObserver : MonoBehaviour
{
    private void Start()
    {
        onEnemyDied = new UnityEvent();
        onEnemySpawned = new UnityEvent();
        onWaveFinished = new UnityEvent();
        onWaveStarted = new UnityEvent();
    }

    public static UnityEvent onEnemyDied = new UnityEvent();
    public static UnityEvent onEnemySpawned = new UnityEvent();
    public static UnityEvent onWaveStarted = new UnityEvent();
    public static UnityEvent onWaveFinished = new UnityEvent();
}
