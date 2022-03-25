using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    public List<Event> availableEvents;
    public List<Event> eventWithPrecondition;
    public List<Event> usedEvents;

    public void Awake()
    {
        CreateAllEvents();
    }

    public void CreateAllEvents()
    {
        foreach (Event e in Database.instance.eventsDb.availableEvents)
        {
            availableEvents.Add(e);
        }

        foreach (Event e in Database.instance.eventsDb.eventsWithPrecondition)
        {
            eventWithPrecondition.Add(e);
        }

    }

    public Event getRandomEvent()
    {
        return availableEvents[Random.Range(0, availableEvents.Count)];
    }
}
