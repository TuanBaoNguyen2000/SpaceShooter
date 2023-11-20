using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawner : Spawner
{
    public static EnemySpawner Instance { get; private set; }

    private void Awake()
    {
        if (EnemySpawner.Instance != null)
            Debug.LogError("Only 1 EnemySpawner allow to exist!");
        EnemySpawner.Instance = this;
    }

}

