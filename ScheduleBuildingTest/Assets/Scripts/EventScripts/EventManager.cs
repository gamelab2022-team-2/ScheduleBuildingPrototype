using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // this class will manage the movement of events between different places in the event database 

    public Event selectedEvent;
    public EventDisplay eventDisplay;

    public static EventManager instance;

    public void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // When the event Canvas is set to active selected a new event 
    public void OnEnable()
    {
        selectedEvent = Database.instance.getRandomEvent();
        eventDisplay.SetUI(selectedEvent);
        Debug.Log("event selected");
    }

    // TO DO : implement function to be called at the beginning of the game to reinitialize the database

}
