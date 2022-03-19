using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class InitialState : GameState
{
    public InitialState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
        nextState = gsm.drawPhase;
    }
    
    public override void Tick()
    {
        base.Tick();
    }
    public override void InitializeNextState()
    {
        nextState = stateMachine.drawPhase;
    }
}
        