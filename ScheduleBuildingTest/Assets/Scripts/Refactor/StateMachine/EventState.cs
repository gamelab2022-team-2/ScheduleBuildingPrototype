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
            //TODO: will eventually be "discussion board phase" which does not exist yet
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

    }

    
}
