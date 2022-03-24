using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds anxiety cards - if cards are not played
/// Adds motivation or grades - added by certain choice
/// </summary>
public class ResolutionState : GameState
{
    public ResolutionState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
    }
    
    public override void InitializeNextState()
    {
        nextState = stateMachine.discardPhase;
    }

    public override void OnStateEnter()
    {
        ResolutionPhase();
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


        for(int i = 0; i < player.hand.Count; i++)
        {
            Card currCard = player.hand.GetAtIndex(i);
            player.motivation.runtimeValue += currCard.cardData.motivation;
            player.grade.runtimeValue += currCard.cardData.grades;
            Debug.Log(player.grade.runtimeValue);

        }

            Debug.Log("cards in Hand resolving");

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
