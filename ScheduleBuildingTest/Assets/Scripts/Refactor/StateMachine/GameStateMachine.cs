using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
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

    public StringVariable currentStateString;

    [Header("GameEvents")] 
    public GameEvent changeStateEvent;

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
        return player.motivation <= 0;
    }

}
