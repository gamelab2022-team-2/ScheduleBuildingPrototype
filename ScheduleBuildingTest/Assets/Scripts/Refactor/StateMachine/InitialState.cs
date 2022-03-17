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
    
    public override void InitializeNextState()
    {
        nextState = _stateMachine.drawPhase;
    }
}
        