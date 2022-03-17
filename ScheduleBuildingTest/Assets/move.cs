using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 desiredPosition = Vector3.zero;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desiredPosition,Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W))
        {
            desiredPosition.x += 5;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(desiredPosition,Vector3.one);
    }
}
