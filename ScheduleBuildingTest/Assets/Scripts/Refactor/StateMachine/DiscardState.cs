using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscardState : GameState
{
    public DiscardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    public override void InitializeNextState()
    {
        nextState = _stateMachine.drawPhase;
    }


    public override void Tick()
    {
        base.Tick();
        DiscardPhase();
        
        // if condition -> next phase (Game Over)
        // if condition -> next phase (Event Phase)
        if (GameOverCondition())
        {
            _stateMachine.ChangeState(_stateMachine.eventPhase);
        }
    }

    public void DiscardPhase()
    {
        // send all cards in hand to the discard set
        _player.DiscardHand();
        // send all cards in schedule to the discard set
        _player.DiscardSchedule();
        
        // Send cards in hand and schedule to discard pile
        // while (_player.deck.Count > 0)
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
}
