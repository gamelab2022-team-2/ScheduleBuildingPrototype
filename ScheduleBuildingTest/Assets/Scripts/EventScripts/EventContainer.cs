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

        Debug.Log("Event select = " + eventSelect.title);
        return eventSelect;
    }

    public void UnlockEvent(int id)
    {

        Event unlocked = FindEventByIdInPrecon(id);
        availableEvents.Add(unlocked);
        eventWithPrecondition.Remove(unlocked);
    }

    public Event FindEventByIdInPrecon(int id)
    {
        int index = -1;
        for (int j = 0; j < eventWithPrecondition.Count; j++)
        {
            if (eventWithPrecondition[j].eventID == id)
            {
                index = j;
                break;
            }
        }
        if (index > -1)
            return eventWithPrecondition[index];
        else
            return null;
    }

    public Event FindEventByIdInAvail(int id)
    {
        bool found = false;
        for (int j = 0; j < availableEvents.Count; j++)
        {
            if (availableEvents[j].eventID == id)
            {
                found = true;
                Event eventSelect = availableEvents[j];
                availableEvents.Remove(eventSelect);
                usedEvents.Add(eventSelect);
                eventManager.selectedEvent = eventSelect;
                return eventSelect;
            }
        }
        return null;
    }
}
