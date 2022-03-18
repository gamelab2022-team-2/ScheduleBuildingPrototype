using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverState : GameState
{
    public GameOverState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    public override void Tick()
    {
        base.Tick();
    }
    public override void InitializeNextState()
    {
        nextState = _stateMachine.initialState;
    }
}
