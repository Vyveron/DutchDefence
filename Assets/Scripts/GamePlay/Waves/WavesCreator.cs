using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WavesCreator : MonoBehaviour
{
    public WaveData waveData;

    public List<GameObject> CreateWave(float difficulty)
    {
        float difficultyKoef = waveData.difficultyCurve.Evaluate(difficulty) + (int)difficulty;
        int enemiesAmount = (int)(waveData.enemiesAmount * difficultyKoef);
        List<EnemyInstance> possibleEnemies = new List<EnemyInstance>();
        List<GameObject> enemies = new List<GameObject>();
        
        for(int i = 0; i < waveData.possibleEnemies.Count; i++)
        {
            EnemyInstance possibleEnemy = waveData.possibleEnemies[i];

            if (possibleEnemy.Difficulty <= difficultyKoef)
            {
                possibleEnemies.Add(possibleEnemy);
            }
        }

        for(int i = 0; i < enemiesAmount; i++)
        {
            GameObject enemy = possibleEnemies[Random.Range(0, possibleEnemies.Count)].enemy;
            enemies.Add(enemy);
        }

        return enemies;
    }
}
