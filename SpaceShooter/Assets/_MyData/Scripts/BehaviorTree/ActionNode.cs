using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionNode : Node
{
    private Func<NodeState> action;

    public ActionNode(Func<NodeState> action) 
    {
        this.action = action;
    }

    public override NodeState Evaluate()
    {
        return this.action.Invoke();
    }
}

