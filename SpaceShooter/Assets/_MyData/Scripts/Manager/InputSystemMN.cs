using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputSystemMN : Singleton<InputSystemMN>
{
    [SerializeField] private Vector3 mouseWorldPos;
    public Vector3 MouseWorldPos { get => mouseWorldPos; }

    [SerializeField] private float onFiring;
    public float OnFiring { get => onFiring; }

    private void Update()
    {
        this.GetMouseDown();
    }

    private void FixedUpdate()
    {
        this.GetMousePos();
    }

    protected virtual void GetMousePos()
    {
        this.mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    protected virtual void GetMouseDown()
    {
        this.onFiring = Input.GetAxis("Fire1");
    }
}
