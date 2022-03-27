using UnityEngine;

namespace Game.StateMachine
{
    public class DiscardState : GameState
    {
        public DiscardState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }

        public override GameState NextState
        {
            get => stateMachine.GameOverCondition()? stateMachine.gameOverState : EventOrDraw();
        }

        public GameState EventOrDraw()
        {
            if (GameManager.Instance.turn % 2 == 0)
            {
                Debug.Log(GameManager.Instance.turn);
                return stateMachine.eventPhase;
            }
                
            return stateMachine.drawPhase;
        }   

        public override void InitializeNextState()
        {
            nextState = stateMachine.drawPhase;
        }


        public override void Tick()
        {
            base.Tick();
            if (TimeSinceEnter > 2)
            {
                stateMachine.ChangeState(NextState);
            }
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnDiscardPhaseEnter.Raise();
            // send all cards in hand to the discard set
            player.DiscardHand();
            // send all cards in schedule to the discard set
            // player.DiscardSchedule();
            player.ClearShapes();
            player.schedule.ClearSchedule();

        }

        public override void OnStateExit()
        {
            stateMachine.OnDiscardPhaseExit.Raise();
        }
    }
}
