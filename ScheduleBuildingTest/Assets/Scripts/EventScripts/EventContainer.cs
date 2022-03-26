using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    public List<Event> availableEvents;
    public List<Event> eventWithPrecondition;
    public List<Event> usedEvents;
    
    

    public EventDisplay eventDisplay;

    public Event eventSelect;

    public EventManager eventManager;

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

    public Event GetRandomEvent()
    {
        eventSelect = availableEvents[Random.Range(0, availableEvents.Count)];
        availableEvents.Remove(eventSelect);
        usedEvents.Add(eventSelect);

        eventManager.selectedEvent = eventSelect;

        if(eventSelect.eventUnlock != null)
        {
            Event unlocked = eventSelect.eventUnlock;
            availableEvents.Add(unlocked);
            eventWithPrecondition.Remove(unlocked);
        }

        Debug.Log("Event select = " + eventSelect.title);
        return eventSelect;
    }
}
