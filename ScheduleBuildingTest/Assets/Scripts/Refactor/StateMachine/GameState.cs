using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameState
{
    protected GameStateMachine _stateMachine;
    protected Player _player;
    public GameState(GameStateMachine gsm, Player p)
    {
        _stateMachine = gsm;
        _player = p;
    }
    
    /// <summary>
    /// Code within this function of the current state will be called on Update.
    /// Will likely be used to animate the game.
    /// </summary>
    public virtual void Tick(){}

    /// <summary>
    /// Called when the current state is first entered, after exiting the previous state.
    /// </summary>
    public virtual void OnStateEnter()
    {
        
    }

    /// <summary>
    /// Called when when exiting current state, before entering another.
    /// </summary>
    public virtual void OnStateExit()
    {
        
    }
    
    // TODO: make this more robust
    public virtual bool GameOverCondition()
    {
        return false;
    }

    public virtual void ApplyChoice(int selection)
    {
        Debug.Log("game state button pressed");
    }

}
