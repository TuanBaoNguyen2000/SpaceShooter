using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : CompositeNode
{
    public Sequence(List<Node> childNodes)
    {
        this.childNodes = childNodes;
    }

    public override NodeState Evaluate()
    {
        if (childNodes == null) return NodeState.FAILURE;

        foreach(Node node in childNodes)
        {
            NodeState result = node.Evaluate();

            if (result != NodeState.SUCCESS) return result;
        }

        return NodeState.SUCCESS;
    }
}

