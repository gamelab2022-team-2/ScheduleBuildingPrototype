using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class GameStateMachine : MonoBehaviour
{
    [Header("Fields")] 
    public Player player;
    public GameObject eventCanvas;
    public StringVariable currentStateString;
    
    [Header("Current State")] 
    public GameState currentState;
    
    [Header("Game States")] 
    public InitialState initialPhase;
    public DrawState drawPhase;
    public PlaceState placePhase;
    public ResolutionState resolutionPhase;
    public DiscardState discardPhase;
    public EventState eventPhase;
    public GameOverState gameOverState;

    [Header("GameEvents")] 
    public GameEvent changeStateEvent;
    [Header("Game State Events")] 
    public GameEvent OnInitialPhaseEnter, OnInitialPhaseExit;
    public GameEvent OnDrawPhaseEnter, OnDrawPhaseExit;
    public GameEvent OnPlacePhaseEnter, OnPlacePhaseExit;
    public GameEvent OnResolutionPhaseEnter, OnResolutionPhaseExit;
    public GameEvent OnDiscardPhaseEnter, OnDiscardPhaseExit;
    public GameEvent OnEventPhaseEnter, OnEventPhaseExit;
    public GameEvent OnGameOverStateEnter;
  

    public void Awake()
    {
        if(!player) player = GetComponent<Player>();
        
        initialPhase = new InitialState(this, player);
        drawPhase = new DrawState(this, player);
        placePhase = new PlaceState(this, player);
        resolutionPhase = new ResolutionState(this, player);
        discardPhase = new DiscardState(this, player);
        eventPhase = new EventState(this, player);
        gameOverState = new GameOverState(this, player);
        
        initialPhase.InitializeNextState();
        drawPhase.InitializeNextState();
        placePhase.InitializeNextState();
        resolutionPhase.InitializeNextState();
        discardPhase.InitializeNextState();
        eventPhase.InitializeNextState();
        gameOverState.InitializeNextState();

        
        currentState = initialPhase;
        currentState.OnStateEnter();
        
    }

    public void Update()
    {
        
        currentState.Tick();
    }

    public void ChangeState(GameState state)
    {
        currentState.OnStateExit();
        currentState = state;
        currentStateString.runtimeValue = currentState.GetType().ToString();
        changeStateEvent.Raise();
        currentState.OnStateEnter();
    }
    
    public void ButtonPress(int button)
    {
        Debug.Log("button pressed");
        currentState.ApplyChoice(button);
    }


    public void NextState()
    {
        ChangeState(currentState.NextState);
        Debug.Log("Current State: " + currentState);
    }

    public bool GameOverCondition()
    {
        return player.motivation.runtimeValue <= 0;
    }

}
