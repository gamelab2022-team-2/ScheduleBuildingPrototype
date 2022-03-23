using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleSlot : MonoBehaviour
{
    private bool isTaken;
    private Color baseColor = new Color(127f / 255f, 185f / 255f, 55f / 255f);
    private Color takenColor = new Color(16f / 255f, 29f / 255f, 0f);
    public void takeSlot()
    {

        isTaken = true;
        transform.GetComponent<Renderer>().material.color = takenColor;
    }
    public void releaseSlot()
    {

        isTaken = false;
        transform.GetComponent<Renderer>().material.color = baseColor;
    }
    public bool isSlotFree()
    {

        return !isTaken;
    }
}
