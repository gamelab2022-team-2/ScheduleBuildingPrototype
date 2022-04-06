using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventContainer : MonoBehaviour
{
    public List<Event> availableEvents;
    public List<Event> eventWithPrecondition;
    public List<Event> usedEvents;

    public int karma = 50;

    public Player _player;

    public EventDisplay eventDisplay;

    public Event eventSelect;

    public EventManager eventManager;

    public static EventContainer instance;

    public void Start()
    {
        CreateAllEvents();
        _player = FindObjectOfType<Player>();
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

        eventSelect = AIGetNextEvent();
        availableEvents.Remove(eventSelect);
        usedEvents.Add(eventSelect);

        if (Game.GameManager.Instance.turn.runtimeValue == 10)
        {
            eventSelect = FindEventByIdInPrecon(13);
        }

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
        for (int j = 0; j < availableEvents.Count; j++)
        {
            if (availableEvents[j].eventID == id)
            {
                Event eventSelect = availableEvents[j];
                availableEvents.Remove(eventSelect);
                usedEvents.Add(eventSelect);
                eventManager.selectedEvent = eventSelect;
                return eventSelect;
            }
        }
        return null;
    }
    
    public void UpdateKarma()
    {
        int k = karma;
        int t = Game.GameManager.Instance.turn.runtimeValue % 10;
        k -= (_player.motivation.runtimeValue - 25 + _player.motivation.runtimeValue - 4*t);
        k += 5 * (_player.anxiety.runtimeValue - 3);
        karma = k;

    }
    public Event AIGetNextEvent()
    {
        Event potentialEvent1 = availableEvents[Random.Range(0, availableEvents.Count)];
        if (availableEvents.Count < 2) return potentialEvent1;
        int event1value = Mathf.Abs(potentialEvent1.eventKarma - karma) - potentialEvent1.eventPriority;
       
        Event potentialEvent2 = availableEvents[Random.Range(0, availableEvents.Count)];
        bool eventFound = false;
        while (!eventFound)
        {
            potentialEvent2 = availableEvents[Random.Range(0, availableEvents.Count)];
            if (potentialEvent2.eventID != potentialEvent1.eventID) eventFound = true;
        }
        int event2value = Mathf.Abs(potentialEvent2.eventKarma - karma) - potentialEvent2.eventPriority;
        if (availableEvents.Count < 3)
        {
            if (event1value < event2value) return potentialEvent1;
            else return potentialEvent2;
        }
        eventFound = false;
        Event potentialEvent3 = availableEvents[Random.Range(0, availableEvents.Count)];
        while (!eventFound)
        {
            potentialEvent3 = availableEvents[Random.Range(0, availableEvents.Count)];
            if (potentialEvent3.eventID != potentialEvent1.eventID && potentialEvent3.eventID != potentialEvent2.eventID) eventFound = true;
        }
        int event3value = Mathf.Abs(potentialEvent3.eventKarma - karma) - potentialEvent3.eventPriority;
        if (event1value < event2value && event2value < event3value) return potentialEvent1;
        else if (event2value < event3value) return potentialEvent2;
        else return potentialEvent3;
    }

}
