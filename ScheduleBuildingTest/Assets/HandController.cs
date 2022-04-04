using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform[] slots;

    public float spacing = 2f;

    private void OnValidate()
    {
        if (slots == null) return;
        var offset = (slots.Length * spacing)/ 2;
        var pos = transform.position;
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].position = new Vector3(pos.x - offset + ((i) * spacing) + spacing*0.5f, pos.y, pos.x);
        }
    }

    private void OnDrawGizmos()
    {
        if (slots == null) return;
        foreach (var slot in slots)
        {
            Gizmos.DrawCube(slot.position,Vector3.one);
        }
    }
}
