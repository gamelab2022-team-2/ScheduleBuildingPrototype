using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiscardState : GameState
{
    public DiscardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }

    public override GameState NextState
    {
        get => stateMachine.GameOverCondition()? stateMachine.gameOverState : EventOrDraw();
    }

    public GameState EventOrDraw()
    {
        if (Game.Instance.turn % 2 == 0)
            return stateMachine.eventPhase;
        return stateMachine.drawPhase;
    }   

    public override void InitializeNextState()
    {
        nextState = stateMachine.drawPhase;
    }


    public override void Tick()
    {
        /*base.Tick();
        DiscardPhase();
        
        // if condition -> next phase (Game Over)
        // if condition -> next phase (Event Phase)
        if (GameOverCondition())
        {
            stateMachine.ChangeState(stateMachine.eventPhase);
        }*/
    }

    public override void OnStateEnter()
    {
        // send all cards in hand to the discard set
        player.DiscardHand();
        // send all cards in schedule to the discard set
        // player.DiscardSchedule();
        player.ClearShapes();
        player.schedule.ClearSchedule();

    }

    public override void OnStateExit()
    {
        stateMachine.OnDiscardPhaseExit.Raise();
    }
}
