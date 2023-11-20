using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyAttack : Node
{
    [SerializeField] private Transform enemyTransform;
    //[SerializeField] protected float shootDelay = 0.5f;
    //[SerializeField] protected float shootTimer = 0f;



    protected virtual void Shooting()
    {
        //this.shootTimer += Time.fixedDeltaTime;
        //if (this.shootTimer < this.shootDelay) return;
        //this.shootTimer = 0f;

        Vector3 spawnPos = enemyTransform.position;
        Quaternion rotation = Quaternion.Euler(0, 0, 90);
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletTwo, spawnPos, rotation);
        if (newBullet == null) return;

        newBullet.gameObject.SetActive(true);
    }

    public override NodeState Evaluate()
    {
        Shooting();
        return NodeState.SUCCESS;
    }
}

[Serializable]
public class EnemyCanAttack : Node
{
    [SerializeField] private int attackOccur;
    [SerializeField] private float shootDelay = 3f;
    [SerializeField] private float shootTimer = 0f;



    private bool CanAttack()
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (this.shootTimer < this.shootDelay) return false;
        this.shootTimer = 0f;

        return UnityEngine.Random.Range(0, 100) < this.attackOccur;
    }

    public override NodeState Evaluate()
    {
        return CanAttack() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
