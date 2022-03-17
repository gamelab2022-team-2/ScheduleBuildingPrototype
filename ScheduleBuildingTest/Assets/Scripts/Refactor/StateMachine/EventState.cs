using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventState : GameState
{
    private GameObject eventPopUp;
    public EventState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
        eventPopUp = _stateMachine.eventCanvas;
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Entering Event Phase");
        if(IsEventTurn()) ActivateEvent();
        else
        {
            //TODO: will eventually be "discussion board phase" which does not exist yet
            _stateMachine.ChangeState(_stateMachine.drawPhase);
        }
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    // if condition -> next phase (Draw Phase)


    public bool IsEventTurn()
    {
        return Game.Instance.turn % 2 == 0;
    }
    
    
    // toggle active of event UI
    public void ActivateEvent()
    {

        eventPopUp.SetActive(true);


    }

    public override void ApplyChoice(int selection)
    {
        EventChoice choice;
        Debug.Log("event state button pressed");

        // check which choice the user has made
        if (selection == 1)
        {
            choice = EventManager.instance.selectedEvent.choice1;
        }
        else
        {
            choice = EventManager.instance.selectedEvent.choice2;
        }

        // apply the changes that are contained in the choice selection

        _player.grade += choice.grade;
        _player.motivation += choice.motivation;

        _player.UpdateUI();

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

        //EndEventPhase();

        if (Game.Instance.turn < 15)
        {
            OpenCardSelector();
        }
    }

    private void OpenCardSelector()
    {
        //open card selector after first 7 events
    }




}
