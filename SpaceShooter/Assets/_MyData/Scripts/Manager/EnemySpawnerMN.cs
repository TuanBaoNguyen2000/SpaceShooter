using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class EnemySpawnerMN : Singleton<EnemySpawnerMN>
{
    [SerializeField] protected EnemySpawner EnemySpawner;
    [SerializeField] protected GameObject SpawnPointHolder;
    [SerializeField] protected List<Transform> points;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTimer = 0f;
    [SerializeField] protected float randomLimit = 10f;

    protected Vector3 pos;
    protected Quaternion rot;


    private void Start()
    {
        LoadPoints();
    }

    private void FixedUpdate()
    {
        EnemySpawning();
    }

    private void LoadPoints()
    {
        if (this.points.Count > 0) return;
        foreach (Transform point in SpawnPointHolder.transform)
        {
            this.points.Add(point);
        }
        Debug.Log(transform.name + ": LoadPoints", gameObject);
    }

    public Transform GetRandomPoint()
    {
        int rand = Random.Range(0, this.points.Count);
        return this.points[rand];
    }

    private void EnemySpawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTimer += Time.fixedDeltaTime;
        if (this.randomTimer < this.randomDelay) return;
        this.randomTimer = 0;

        Transform randPoint = GetRandomPoint();
        this.pos = randPoint.position;
        this.rot = transform.rotation;

        Invoke(nameof(GetEnemyToSpawn), 1f);

    }

    private void GetEnemyToSpawn()
    {
        Transform prefab = EnemySpawner.RandomPrefab();
        Transform obj = EnemySpawner.Spawn(prefab, this.pos, this.rot);
        obj.gameObject.SetActive(true);

    }

    private bool RandomReachLimit()
    {
        int currentEnemy = EnemySpawner.SpawnedCount;
        return currentEnemy >= this.randomLimit;
    }
}

