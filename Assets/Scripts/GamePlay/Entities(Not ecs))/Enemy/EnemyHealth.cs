using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Start()
    {
        base.Start();

        onDied.AddListener(DieCallback);
    }
    protected void DieCallback()
    {
        WaveObserver.onEnemyDied.Invoke();
    }
}
