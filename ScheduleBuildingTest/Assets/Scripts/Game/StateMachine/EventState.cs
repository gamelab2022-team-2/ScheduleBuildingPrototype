using UnityEngine;

namespace Game.StateMachine
{
    /// <summary>
    /// Adds anxiety cards - if a certain choice is selected
    /// Adds motivation or grades - added by certain choice
    /// </summary>
    public class EventState : GameState
    {
        public EventState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
        public override GameState NextState
        {
            get
            {
                if (GameOverCondition()) return stateMachine.gameOverState;
                return stateMachine.newCardPhase;
            }
        }
        
        public override void InitializeNextState()
        {
            nextState = stateMachine.drawPhase;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnEventPhaseEnter.Raise();
        }

        public override void OnStateExit()
        { 
            stateMachine.OnEventPhaseExit.Raise();
        }
    }
}
