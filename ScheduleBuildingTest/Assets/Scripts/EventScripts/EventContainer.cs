using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    public List<Event> availableEvents;
    public List<Event> eventWithPrecondition;
    public List<Event> usedEvents;

    public EventDisplay eventDisplay;

    public static EventContainer instance;

    public void Start()
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
        Event eventSelect = availableEvents[Random.Range(0, availableEvents.Count)];
        availableEvents.Remove(eventSelect);
        usedEvents.Add(eventSelect);

        if(eventSelect.eventUnlock != null)
        {
            Event unlocked = eventSelect.eventUnlock;
            availableEvents.Add(unlocked);
            eventWithPrecondition.Remove(unlocked);
        }

        return eventSelect;
    }
}
