using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionState : GameState
{
    public ResolutionState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    public override void InitializeNextState()
    {
        nextState = stateMachine.discardPhase;
    }

    public override void Tick()
    {
        // base.Tick();
        // ResolutionPhase();
        // if(GameOverCondition()) stateMachine.ChangeState(stateMachine.gameOverState); // Game Over
        // else stateMachine.ChangeState(stateMachine.discardPhase); // Next Phase
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
            /*if (!card.inSchedule)
            {g
                motivation += card.inHandMotiv;
                CardManager.instance.AddAnxiety(card.anxiety);
                Debug.Log(card.anxiety + " added");
                UpdateGauges();
            }*/

            //TODO: Do we want to increase motivation when cards are in hand AND in the schedule?
            /*if (card.inSchedule)
            {
                grades += card.grades;
                motivation += card.motivation;
                UpdateGauges();
            }*/
        }
        //if(GameOverCondition()) stateMachine.ChangeState(stateMachine.gameOverState); // Game Over
        //else stateMachine.ChangeState(stateMachine.discardPhase); // Next Phase
        //phase++;
    }

    /// <summary>
    /// Check if a Game Over Condition has been met.
    /// </summary>
    /// <returns>True if player's motivation is less than or equal to 0, otherwise returns false.</returns>
    public override bool GameOverCondition()
    {
        if (player.motivation.runtimeValue <= 0) return true;
        return false;
    }
    
    // if condition -> next phase (Game Over)
    // if condition -> next phase (Discard State)
}
