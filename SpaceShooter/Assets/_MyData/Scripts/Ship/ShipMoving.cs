using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMoving : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPos;
    [SerializeField] protected float speed = 0.05f;

    private void FixedUpdate()
    {
        this.GetTargetPos();
        //this.LookAtTarget();
        this.Moving();
    }

    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.MoveTowards(transform.parent.position, this.targetPos, this.speed);
        transform.parent.position = newPos;
    }

    protected virtual void GetTargetPos()
    {
        this.targetPos = InputSystemMN.Instance.MouseWorldPos;
        this.targetPos.z = 0f;
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPos - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
}
