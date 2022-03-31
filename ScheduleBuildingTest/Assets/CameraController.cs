using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform lookPos1, lookPos2,lookPos3,lookPos4;
    private void FixedUpdate()
    {
        var lookLeft = Quaternion.LookRotation(lookPos1.position - transform.position);
        var lookRight= Quaternion.LookRotation(lookPos2.position - transform.position);
        var lookUp = Quaternion.LookRotation(lookPos3.position - transform.position);
        var lookDown= Quaternion.LookRotation(lookPos4.position - transform.position);
        
        var desiredQuatY = Quaternion.Lerp(lookDown,lookUp,Input.mousePosition.y/Screen.height);
        var desiredQuatX= Quaternion.Lerp(lookRight,lookLeft,Input.mousePosition.x/Screen.width);
        var desiredQuat = Quaternion.Slerp(desiredQuatX,desiredQuatY,0.5f);
        transform.rotation = Quaternion.Slerp(transform.rotation,desiredQuat,Time.deltaTime);
        
    }
}
 