using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static Database instance;

    public EventDatabase events;

    private void Start()
    {
        events.ReinitializeEventDB();
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

    public Event getRandomEvent()
    {
        return events.availableEvents[Random.Range(0, events.availableEvents.Count)];
    }


}
