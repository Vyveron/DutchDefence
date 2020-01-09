using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(WavesCreator))]
public class WaveSpawner : MonoBehaviour
{
    public static int wave;
    public static int enemiesLeft;

    public WaveData waveData;
    public float time = 20f;
    public float startDifficulty = 10f;

    private float _difficulty;
    private WavesCreator _wavesCreator;
    private List<GameObject> _enemies = new List<GameObject>();


    private void Start()
    {
        _wavesCreator = GetComponent<WavesCreator>();
        wave = 0;
        enemiesLeft = 0;
        _difficulty = startDifficulty;

        WaveObserver.onEnemyDied.AddListener(DecreaseEnemiesAmountLeft);
        WaveObserver.onWaveFinished.AddListener(StartWave);
        Path.AddRequestOnCreate(StartWave);
    }

    public void GetEnemies()
    {
        _enemies = _wavesCreator.CreateWave(_difficulty);
    }
    public void StartWave()
    {
        float minStep = waveData.difficultyStep / 2;
        float maxStep = waveData.difficultyStep + minStep;
        _difficulty += Random.Range(minStep, maxStep);

        GetEnemies();
        enemiesLeft = _enemies.Count;

        StartCoroutine(StartSpawning(time));
        WaveObserver.onWaveStarted.Invoke();
    }

    private IEnumerator StartSpawning(float durationTime)
    {
        WaveObserver.onWaveStarted.Invoke();
        int i = 0;
        for(float timeSpent = 0f; i < _enemies.Count; timeSpent += Time.deltaTime)
        {
            if (timeSpent >= (durationTime / _enemies.Count * i))
            {
                SpawnEnemy(i);
                i++;
            }
            yield return null;
        }
    }
    private void SpawnEnemy(int index)
    {
        Vector2 spawnPoint = Path.VectorPath[0];
        GameObject enemy = Instantiate(_enemies[index], spawnPoint, Quaternion.identity);
        WaveObserver.onEnemySpawned.Invoke();
    }

    protected void DecreaseEnemiesAmountLeft()
    {
        enemiesLeft--;
        if(enemiesLeft <= 0)
        {
            WaveObserver.onWaveFinished.Invoke();
        }
    }
    protected void IncreaseEnemyAmountLeft()
    {
        enemiesLeft++;
    }
}
