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
    
    public void BlockRandomSlot()
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

    public void ClearSchedule()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].releaseSlot();
        }
    }

    public void BlockColumn(int i)
    {
        int rowX = -6 + (2 * i);
        for (int j = 0; j < slots.Length; j++)
        {
            if (slots[j].transform.position.x == rowX)
                slots[j].takeSlot();
        }
    }

    public void BlockRow(int i)
    {
        float colY = (float)(4.5 - (float)i);
        for (int j = 0; j < slots.Length; j++)
        {
            if (slots[j].transform.position.y == colY)
                slots[j].takeSlot();
        }
    }

    // block i blocks in a row from a random row
    public void BlockInRow(int i) 
    {
        int index;
        index = (int)Random.Range(0f, (float)slots.Length-i);
        if (slots[index].isSlotFree())
        {
            for(int s = 0; s <= i; s++)
            {
                slots[index+s].takeSlot();
            }
            
        }
    }

    // block i cubes in a row from a column
    public void BlockInColumn(int i)
    {
        int index;
        index = (int)Random.Range(0f, (float)slots.Length- 5*i);
        if (slots[index].isSlotFree())
        {
            for (int s = 0; s < i*5; s+=5)
            {
                slots[index + s].takeSlot();
            }

        }
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        deleteBlock();
    //    }
    //}

    //public void deleteBlock()

    //{

    //    GridObject[] gridObjects = FindObjectsOfType<GridObject>();


    //    foreach (GridObject go in gridObjects)

    //    {

    //        if (go.isInGrid)

    //        {

    //            Destroy(go.gameObject);

    //        }


    //    }


    //    for (int i = 0; i < slots.Length; i++)

    //    {

    //        slots[i].releaseSlot();

    //    }

    //}
}
