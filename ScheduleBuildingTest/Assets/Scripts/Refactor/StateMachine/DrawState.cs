using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawState : GameState
{
    public DrawState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    
    // if condition -> next phase (Place State)
    public override void InitializeNextState()
    {
        nextState = _stateMachine.placePhase;
    }

    public override void Tick()
    {
        
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
        base.OnStateExit();
    }

    public void Draw()
    {
        while (_player.hand.Count < 5) // Draw while there are less than 5 cards in hand
        {
            if (_player.deck.Count > 0) // Draw from deck if there are more than 0 cards
            {
                Card drawnCard = _player.deck.Draw();
                _player.hand.Add(drawnCard);
            }
            else _player.ReplenishDeck(); // if there are no more cards in the deck, add all discarded cards into the deck

            // Not sure what this does (I assume it is animation)
            // if (_player.deck.Count == 0)
            // {
            //     deck.SetActive(false);
            // }
        }
    }
    

}
