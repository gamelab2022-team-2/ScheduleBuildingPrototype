using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine
{
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
            stateMachine.OnNewCardPhaseEnter.Raise();

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
            return GameManager.Instance.turn < 15;
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
}
