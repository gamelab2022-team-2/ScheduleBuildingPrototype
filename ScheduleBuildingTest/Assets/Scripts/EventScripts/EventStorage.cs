using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventStorage : MonoBehaviour
{
    // this script stores all the events in a list en instantiates a random event when an event phase is triggered
    // NOTE: using list so we can add events to list when an event unlocks further events

    public List<GameObject> eventList;
    public static EventStorage instance;

    public GameObject PickRandomEvent()
    {
        return eventList[Random.Range(0, eventList.Count)];
    }

}
