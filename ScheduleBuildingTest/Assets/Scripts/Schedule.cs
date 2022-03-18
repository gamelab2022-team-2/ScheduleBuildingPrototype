using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    [SerializeField] ScheduleSlot slot11;
    [SerializeField] ScheduleSlot slot12;
    [SerializeField] ScheduleSlot slot13;
    [SerializeField] ScheduleSlot slot14;
    [SerializeField] ScheduleSlot slot15;
    [SerializeField] ScheduleSlot slot21;
    [SerializeField] ScheduleSlot slot22;
    [SerializeField] ScheduleSlot slot23;
    [SerializeField] ScheduleSlot slot24;
    [SerializeField] ScheduleSlot slot25;
    [SerializeField] ScheduleSlot slot31;
    [SerializeField] ScheduleSlot slot32;
    [SerializeField] ScheduleSlot slot33;
    [SerializeField] ScheduleSlot slot34;
    [SerializeField] ScheduleSlot slot35;
    [SerializeField] ScheduleSlot slot41;
    [SerializeField] ScheduleSlot slot42;
    [SerializeField] ScheduleSlot slot43;
    [SerializeField] ScheduleSlot slot44;
    [SerializeField] ScheduleSlot slot45;
    [SerializeField] ScheduleSlot slot51;
    [SerializeField] ScheduleSlot slot52;
    [SerializeField] ScheduleSlot slot53;
    [SerializeField] ScheduleSlot slot54;
    [SerializeField] ScheduleSlot slot55;
    [SerializeField] ScheduleSlot slot61;
    [SerializeField] ScheduleSlot slot62;
    [SerializeField] ScheduleSlot slot63;
    [SerializeField] ScheduleSlot slot64;
    [SerializeField] ScheduleSlot slot65;
    [SerializeField] ScheduleSlot slot71;
    [SerializeField] ScheduleSlot slot72;
    [SerializeField] ScheduleSlot slot73;
    [SerializeField] ScheduleSlot slot74;
    [SerializeField] ScheduleSlot slot75;
    [SerializeField] ScheduleSlot slot81;
    [SerializeField] ScheduleSlot slot82;
    [SerializeField] ScheduleSlot slot83;
    [SerializeField] ScheduleSlot slot84;
    [SerializeField] ScheduleSlot slot85;

    ScheduleSlot[] slots;
    void Start()
    {
        slots = GetComponentsInChildren<ScheduleSlot>();
        
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
