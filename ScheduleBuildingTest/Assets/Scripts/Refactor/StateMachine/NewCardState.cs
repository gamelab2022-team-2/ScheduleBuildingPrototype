using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds anxiety cards - if cards are not played
/// Adds motivation or grades - added by certain choice
/// </summary>
public class NewCardState : GameState
{
    public NewCardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }

    public override void InitializeNextState()
    {
        nextState = stateMachine.drawPhase;
    }

    public override void Tick()
    {

    }
    public override void OnStateExit()
    { 
        stateMachine.OnEventPhaseExit.Raise();
    }
    
    public override void OnStateEnter()
    {
        base.OnStateEnter();
    }
}
