using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DrawState : GameState
{
    public DrawState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    
    // if condition -> next phase (Place State)
    public override void InitializeNextState()
    {
        nextState = stateMachine.placePhase;
    }

    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public void Draw()
    {
        _player.DrawFromDeck();
    }
    

}
