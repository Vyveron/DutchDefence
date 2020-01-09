using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Wave Sample", menuName = "TD/Waves/New Wave Sample")]
public class WaveData : ScriptableObject
{
    public List<EnemyInstance> possibleEnemies;
    public AnimationCurve difficultyCurve;
    [Range(0f, 1f)] public float enemiesRangeInWave;
    public float difficultyStep = 0.05f;
    public int enemiesAmount;
}

[System.Serializable]
public struct EnemyInstance
{
    public GameObject enemy;
    public float Difficulty
    {
        get { return difficulty; }
        set { difficulty = Mathf.Clamp01(value); }
    }
    [SerializeField] private float difficulty;
}