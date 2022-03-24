using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Adds anxiety cards - if cards are not played
/// Adds motivation or grades - added by certain choice
/// </summary>
public class NewCardState : GameState
{
    private GameObject newCardPopUp;
    private List<Card> threeCards;
    public NewCardState(GameStateMachine gsm, Player player) : base(gsm, player)
    {
        newCardPopUp = stateMachine.newCardCanvas;
    }

    public override void InitializeNextState()
    {
        nextState = stateMachine.drawPhase;
    }

    public override void Tick()
    {

    }
    public override void OnStateExit()
    {
        newCardPopUp.SetActive(false);
        stateMachine.OnNewCardPhaseExit.Raise();
    }
    
    public override void OnStateEnter()
    {
        base.OnStateEnter();

        threeCards = new List<Card>();

        player.allCards.Shuffle();

        for(int i = 0; i < 3; i++)
        {
            threeCards.Add(player.allCards.Draw());
        }

        if (IsNewCardTurn()) newCardPopUp.SetActive(true);
        else
        {
            stateMachine.ChangeState(stateMachine.drawPhase);
        }
        

    }

    public bool IsNewCardTurn()
    {
        return Game.Instance.turn < 15;
    }

    public override void ApplyChoice(int selection)
    {
        Debug.Log("new card state button pressed");

        if(threeCards.Count != 0)
        {
            player.deck.Add(threeCards[selection - 1]);
        }

        stateMachine.ChangeState(stateMachine.drawPhase);
    }
}
