namespace Game.StateMachine
{
    public class WinState : GameState
    {
        public WinState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
        public override void InitializeNextState()
        {
            nextState = stateMachine.initialPhase;
        }

        public override void OnStateEnter()
        {
            stateMachine.OnWinStateEnter.Raise();
        }

        public override void Tick()
        {
            base.Tick();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();
        }

    }
}
