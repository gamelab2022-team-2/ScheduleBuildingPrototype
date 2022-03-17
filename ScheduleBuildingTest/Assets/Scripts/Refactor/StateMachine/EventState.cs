using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventState : GameState
{
    
    public EventState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }

    public override void OnStateEnter()
    {
        base.OnStateEnter();
        Debug.Log("Entering Event Phase");
        if(IsEventTurn()) ActivateEvent();
        else
        {
            _stateMachine.ChangeState(_stateMachine.drawPhase);
        }
    }

    // if condition -> next phase (Draw Phase)


    public bool IsEventTurn()
    {
        return Game.Instance.turn % 2 == 0;
    }
    
    
    // Doesn't do anything right now
    public void ActivateEvent()
    {
        // every other turn, activate an event -> next phase (draw phase)
        /*if (turn % 2 == 0)
        {
            eventCanvas.SetActive(true);
        }
        else
        {
            phase = 0;
        }*/
        
    }

    
}
