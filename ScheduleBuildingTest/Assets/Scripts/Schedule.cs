using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{


    ScheduleSlot[] slots;
    void Awake()
    {
        slots = transform.GetComponentsInChildren<ScheduleSlot>();
        
    }
    
    public void blockRandomSlot()
    {
        bool blocked = false;
        int index;
        while (!blocked)
        {
            index = (int)Random.Range(0f, (float)slots.Length);
            if (slots[index].isSlotFree())
            {
                slots[index].takeSlot();
                blocked = true;
            }
        }
    }
    
}
