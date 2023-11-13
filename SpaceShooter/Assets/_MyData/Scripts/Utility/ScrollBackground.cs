using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed;

    public Renderer rdr;
    private Vector2 savedOffset;

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 1);
        Vector2 offset = new Vector2(0, y);
        rdr.sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}

