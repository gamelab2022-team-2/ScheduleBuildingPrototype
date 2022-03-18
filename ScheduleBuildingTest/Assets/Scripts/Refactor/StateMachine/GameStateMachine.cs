using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    public Player player;
    public GameState currentState;
    public InitialState initialState;
    public DrawState drawPhase;
    public PlaceState placePhase;
    public ResolutionState resolutionPhase;
    public DiscardState discardPhase;
    public EventState eventPhase;
    public GameOverState gameOverState;

    public GameObject eventCanvas;

    public void Awake()
    {
        if(!player) player = GetComponent<Player>();
        
        initialState = new InitialState(this, player);
        drawPhase = new DrawState(this, player);
        placePhase = new PlaceState(this, player);
        resolutionPhase = new ResolutionState(this, player);
        discardPhase = new DiscardState(this, player);
        eventPhase = new EventState(this, player);
        gameOverState = new GameOverState(this, player);
        
        initialState.InitializeNextState();
        drawPhase.InitializeNextState();
        placePhase.InitializeNextState();
        resolutionPhase.InitializeNextState();
        discardPhase.InitializeNextState();
        eventPhase.InitializeNextState();
        gameOverState.InitializeNextState();

        currentState = initialState;

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
    
    public void ButtonPress(int button)
    {
        Debug.Log("button pressed");
        currentState.ApplyChoice(button);
    }


    public void NextState()
    {
        ChangeState(currentState.nextState);
        Debug.Log("Current State: " + currentState);
    }

}
