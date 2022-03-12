using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameState
{
    protected GameStateMachine _stateMachine;
    protected GameState _nextPhase;
    public GameState(GameStateMachine gsm)
    {
        _stateMachine = gsm;
    }
    
    public virtual void Tick(){}

    public virtual void OnStateEnter()
    {
        
    }

    public virtual void OnStateExit()
    {
        
    }
}
