using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Database : MonoBehaviour
{
    public static Database instance;

    public EventDatabase eventsDb;

    private void Start()
    {
        eventsDb.ReinitializeEventDB();
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
        return eventsDb.availableEvents[Random.Range(0, eventsDb.availableEvents.Count)];
    }


}
