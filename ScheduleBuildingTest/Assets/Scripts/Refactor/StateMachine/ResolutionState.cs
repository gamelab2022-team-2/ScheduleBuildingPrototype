using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionState : GameState
{
    public ResolutionState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    
    /// <summary>
    ///  For each card still in the player's hand after the placement phase,
    /// </summary>
    private void ResolutionPhase()
    {
        Debug.Log("Resolution Started");
        foreach(Card card in CardManager.instance.cardsInHand)
        {
            Debug.Log("cards in Hand resolving");
            if (!card.inSchedule)
            {
                motivation += card.inHandMotiv;
                CardManager.instance.AddAnxiety(card.anxiety);
                Debug.Log(card.anxiety + " added");
                UpdateGauges();
            }

            //TODO: Do we want to increase motivation when cards are in hand AND in the schedule?
            if (card.inSchedule)
            {
                grades += card.grades;
                motivation += card.motivation;
                UpdateGauges();
            }
        }



        phase++;

    }
    
    
    // if condition -> next phase (Game Over)
    // if condition -> next phase (Discard State)
}
