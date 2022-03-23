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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            deleteBlock();
        }
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

    public void deleteBlock()
    {
        GridObject[] gridObjects = FindObjectsOfType<GridObject>();

        foreach (GridObject go in gridObjects)
        {
            if (go.isInGrid)
            {
                Destroy(go.gameObject);
            }
                
        }

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].releaseSlot();
        }
    }
    
}
