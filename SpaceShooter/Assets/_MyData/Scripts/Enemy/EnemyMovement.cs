using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyMovement : Node
{
    [SerializeField] private Transform enemyTransform;
    [SerializeField] private Transform targetPos;
    [SerializeField] private float speed = 0.05f;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private int currentWaypoint = 0;


    public void Moving()
    {
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, this.targetPos.position, this.speed);
    }

    protected void GetTargetPos()
    {
        if (enemyTransform.position == waypoints[currentWaypoint].position)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
        }

        this.targetPos = waypoints[currentWaypoint];
    }

    public override NodeState Evaluate()
    {
        this.GetTargetPos();
        this.Moving();

        return NodeState.SUCCESS;
    }
}
