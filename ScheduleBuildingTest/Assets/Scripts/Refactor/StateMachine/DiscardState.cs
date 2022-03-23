using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DiscardState : GameState
{
    public DiscardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }

    public override GameState NextState
    {
        get => stateMachine.GameOverCondition()? stateMachine.gameOverState : EventOrDraw();
    }

    public GameState EventOrDraw()
    {
        if (Game.Instance.turn % 2 == 0)
            return stateMachine.eventPhase;
        return stateMachine.drawPhase;
    }   

    public override void InitializeNextState()
    {
        nextState = stateMachine.drawPhase;
    }


    public override void Tick()
    {
        /*base.Tick();
        DiscardPhase();
        
        // if condition -> next phase (Game Over)
        // if condition -> next phase (Event Phase)
        if (GameOverCondition())
        {
            stateMachine.ChangeState(stateMachine.eventPhase);
        }*/
    }

    public void DiscardPhase()
    {
        // send all cards in hand to the discard set
        player.DiscardHand();
        // send all cards in schedule to the discard set
        player.DiscardSchedule();
        
        // Send cards in hand and schedule to discard pile
        // while (player.deck.Count > 0)
        // {
        //     Card cardMove = cardsInHand[0];
        //     cardMove.gameObject.SetActive(false);
        //     cardMove.transform.position = discard.transform.position;
        //     cardMove.inHand = false;
        //     cardMove.inSchedule = false;
        //
        //     cardsInHand.RemoveAt(0);
        //     discardPile.Add(cardMove);
        //     discard.SetActive(true);
        // }
        // for (int i = 0; i<availableSlots.Length; i++)
        // {
        //     availableSlots[i] = true;
        // }
        
    }

    public override void OnStateExit()
    {
        stateMachine.OnDiscardPhaseExit.Raise();
    }
}
