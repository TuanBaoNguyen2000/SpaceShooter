using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Node root;
    public EnemyMovement enemyMovement;
    public EnemyAttack enemyAttack;
    public EnemyCanAttack enemyCanAttack;

    private void Start()
    {
        BuildTree();
    }

    private void FixedUpdate()
    {
        root.Evaluate();
    }

    private void BuildTree()
    {
        root = new Sequence(new List<Node>
        {
            new Sequence(new List<Node>
            {
                enemyMovement
            }),

            new Sequence(new List<Node>
            {
                enemyCanAttack,
                enemyAttack
            })
        });
    }
}
