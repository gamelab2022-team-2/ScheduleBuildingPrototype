using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameState
{
    protected GameStateMachine _stateMachine;
    protected Player _player;
    protected GameState _nextPhase;
    public GameState(GameStateMachine gsm, Player p)
    {
        _stateMachine = gsm;
        _player = p;
    }
    
    public virtual void Tick(){}

    public virtual void OnStateEnter()
    {
        
    }

    public virtual void OnStateExit()
    {
        
    }
}
