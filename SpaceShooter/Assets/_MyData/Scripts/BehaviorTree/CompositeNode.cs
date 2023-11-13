using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CompositeNode : Node
{
    protected List<Node> childNodes = new List<Node>();

    public void AddChild(Node node)
    {
        childNodes.Add(node);
    }
}

