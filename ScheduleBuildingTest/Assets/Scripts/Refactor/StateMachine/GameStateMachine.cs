using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState currentState;
    private GameState initialState = new InitialState();
    private GameState drawPhase = new DrawState();
    private GameState placePhase = new PlaceState();
    private GameState resolutionPhase = new ResolutionState();
    private GameState discardPhase = new DiscardState();
    private GameState eventPhase = new EventState();
    private GameState gameOverState = new GameOverState();
    
    public void Update()
    {
        currentState.Tick();
    }

    public void ChangeState(GameState state)
    {
        currentState.OnStateExit();

        currentState = state;
        
        currentState.OnStateEnter();
    }
}
