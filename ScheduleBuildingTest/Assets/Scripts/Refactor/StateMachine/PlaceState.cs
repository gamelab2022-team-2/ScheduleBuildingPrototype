using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceState : GameState
{
    public PlaceState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    public override void Tick()
    {
        base.Tick();
    }
    public override void InitializeNextState()
    {
        nextState = _stateMachine.resolutionPhase;
    }
    
    // if condition -> next phase (Resolution Phase)
    
}
