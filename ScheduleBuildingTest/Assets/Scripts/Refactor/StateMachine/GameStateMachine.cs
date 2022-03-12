using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public GameState currentState;
    public GameState initialState;
    public GameState drawPhase;
    public GameState placePhase;
    public GameState resolutionPhase;
    public GameState discardPhase;
    public GameState eventPhase;
    public GameState gameOverState;

    public void Awake()
    {
        initialState = new InitialState(this);
        drawPhase = new DrawState(this);
        placePhase = new PlaceState(this);
        resolutionPhase = new ResolutionState(this);
        discardPhase = new DiscardState(this);
        eventPhase = new EventState(this);
        gameOverState = new GameOverState(this);
    }

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
