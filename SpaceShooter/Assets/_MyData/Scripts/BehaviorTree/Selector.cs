using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : CompositeNode
{
    public Selector(List<Node> childNodes)
    {
        this.childNodes = childNodes;
    }

    public override NodeState Evaluate()
    {
        if (childNodes == null) return NodeState.FAILURE;

        foreach (Node node in childNodes)
        {
            NodeState result = node.Evaluate();

            if (result != NodeState.FAILURE) return result;
        }

        return NodeState.FAILURE;
    }
}

