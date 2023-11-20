using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallel : CompositeNode
{
    private int successCount;
    private int failureCount;

    public Parallel(List<Node> childNodes)
    {
        this.childNodes = childNodes;
    }

    public override NodeState Evaluate()
    {
        successCount = 0;
        failureCount = 0;

        // Đánh giá tất cả các nút con đồng thời
        foreach (Node node in childNodes)
        {
            NodeState result = node.Evaluate();

            if (result == NodeState.SUCCESS)
                successCount++;
            else if (result == NodeState.FAILURE)
                failureCount++;
        }

        // Xác định trạng thái tổng quát dựa trên số lượng nút con hoàn thành
        if (successCount == childNodes.Count)
            return NodeState.SUCCESS;
        else if (failureCount == childNodes.Count)
            return NodeState.FAILURE;
        else
            return NodeState.RUNNING;
    }
}