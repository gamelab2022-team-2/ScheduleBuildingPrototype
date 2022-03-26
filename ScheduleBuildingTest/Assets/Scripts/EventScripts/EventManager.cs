using System.Collections;
using System.Collections.Generic;
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

        

        // apply the changes that are contained in the choice selection

        //player.grade.runtimeValue += choice.grade;
        //player.motivation.runtimeValue += choice.motivation;

        //if (choice.card != null)
        //CardManager.instance.discardPile.Add(choice.card);
        //CardManager.instance.AddAnxiety(choice.addAnx);
        // CardManager.instance.RemoveAnxiety(choice.remAnx1); TO DO IMPLEMENT THIS
        // CardManager.instance.AddConnection(choice.connect); TO DO IMPLEMENT THIS
        //UpdateGauges();

        //EventManager.instance.MoveToUsed(EventManager.instance.selectedEvent);

        // if an event is unlocked by the current event add it to available event list in database
        //if (choice.unlockedEvent != null)
        //{
        //Database.instance.eventsDb.availableEvents.Add(choice.unlockedEvent);
        //Database.instance.eventsDb.eventsWithPrecondition.Remove(choice.unlockedEvent);
        //}

        stateMachine.NextState();
    }

}
