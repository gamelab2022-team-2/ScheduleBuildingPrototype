using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpin : MonoBehaviour
{
    public float anglePerSecond = 5f;
    public Vector3 rotationAxis = Vector3.up;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(rotationAxis, anglePerSecond * Time.deltaTime);
    }
}
