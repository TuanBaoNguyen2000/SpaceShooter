using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public static BulletSpawner Instance { get; private set; }

    public static string bulletOne = "Bullet_1";
    public static string bulletTwo = "Bullet_2";


    private void Awake()
    {
        if (BulletSpawner.Instance != null)
            Debug.LogWarning("Only 1 BulletSpawner allow to exist!");
        BulletSpawner.Instance = this;
    }
}
