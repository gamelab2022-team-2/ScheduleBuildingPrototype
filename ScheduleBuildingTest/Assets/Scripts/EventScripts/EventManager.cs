using System.Collections;
using System.Collections.Generic;
using Game.StateMachine;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    // this class will manage the movement of events between different places in the event database 

    public Player player;
    public GameStateMachine stateMachine;
    public Event selectedEvent;
    public EventChoice choice;

    public void Start()
    {

    }

    public void ApplyChoice(int selection)
    {
        
        Debug.Log("event state button pressed");

        // check which choice the user has made
        if (selection == 1)
        {
            player.ApplyEventChoice(selectedEvent.choice1);
        }
        else
        {
            player.ApplyEventChoice(selectedEvent.choice2);
        }

        stateMachine.NextState();
    }

}
