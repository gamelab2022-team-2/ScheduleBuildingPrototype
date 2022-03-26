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
        private List<Card> _threeCards;
        public NewCardState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }

        public override void InitializeNextState()
        {
            nextState = stateMachine.drawPhase;
        }

        public override void Tick()
        {

        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnNewCardPhaseEnter.Raise();

            _threeCards = new List<Card>();

            player.allCards.Shuffle();

            for(int i = 0; i < 3; i++)
            {
                _threeCards.Add(player.allCards.Draw());
            }
        }

        public override void OnStateExit()
        {
            stateMachine.OnNewCardPhaseExit.Raise();
        }

        public override void ApplyChoice(int selection)
        {
            Debug.Log("new card state button pressed");

            if(_threeCards.Count != 0)
            {
                player.deck.Add(_threeCards[selection - 1]);
            }

            stateMachine.ChangeState(stateMachine.drawPhase);
        }
    }
}
