using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleSlot : MonoBehaviour
{
    private bool isTaken;
    private Color baseColor = new Color(162f / 255f, 164f / 255f, 166f / 255f);
    private Color takenColor = new Color(79f / 255f, 82f / 255f, 89f/255f);
    
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
