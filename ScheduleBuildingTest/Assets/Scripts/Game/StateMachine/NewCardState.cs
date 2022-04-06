using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine
{
    public class NewCardState : GameState
    {
        public NewCardState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }

        public override GameState NextState
        {
            get
            {
                if (GameOverCondition()) return stateMachine.gameOverState;
                //if (Game.GameManager.Instance.turn.runtimeValue >= 4) return stateMachine.discussionPhase;
                return stateMachine.drawPhase;
            }
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
        }

        public override void OnStateExit()
        {
            stateMachine.OnNewCardPhaseExit.Raise();
        }

        public override bool GameOverCondition()
        {
            if (player.Motivation <= 0) return true;
            return GameManager.Instance.turn.runtimeValue == 10 && player.Grade < 60;
        }

    }
}
