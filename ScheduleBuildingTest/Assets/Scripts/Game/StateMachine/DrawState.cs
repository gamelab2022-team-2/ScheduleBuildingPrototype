using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// adds cards from the deck to the hand
/// activates anxiety cards on the board if drawn
/// </summary>
public class DrawState : GameState
{


    public DrawState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    
    // if condition -> next phase (Place State)
    public override void InitializeNextState()
    {
        nextState = stateMachine.placePhase;
    }

    public override void Tick()
    {

    }

    public override void OnStateEnter()
    {
        stateMachine.OnDrawPhaseEnter.Raise();
        Game.Instance.turn += 1;
        Debug.Log(Game.Instance.turn);
        Draw();

    }

    public override void OnStateExit() 
    {
        foreach (GridObject go in player.gridObjects)
        {
            go.allowedToMove = true;
        }
        base.OnStateExit();
    }

    public void Draw()
    {
        player.DrawFromDeck();
    }
    

}