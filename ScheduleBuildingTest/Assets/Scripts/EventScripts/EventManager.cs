using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{

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

    public void OnEnable()
    {
        selectedEvent = Database.instance.getRandomEvent();
        eventDisplay.SetUI(selectedEvent);
        Debug.Log("event selected");
    }
}
