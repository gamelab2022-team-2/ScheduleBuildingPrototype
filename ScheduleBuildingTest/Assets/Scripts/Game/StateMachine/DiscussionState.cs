using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine
{

    public class DiscussionState : GameState
    {
        public DiscussionState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }

        public override GameState NextState
        {
            get
            {
                if (GameOverCondition()) return stateMachine.gameOverState;
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
            stateMachine.OnDiscussionPhaseEnter.Raise();
            Debug.Log("discussion phase entered!!!");
        }

        public override void OnStateExit()
        {
            stateMachine.OnDiscussionPhaseExit.Raise();
        }

        public override bool GameOverCondition()
        {
            if (player.Motivation <= 0) return true;
            return GameManager.Instance.turn.runtimeValue == 10 && player.Grade < 60;
        }

    }
}
