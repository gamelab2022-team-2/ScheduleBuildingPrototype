namespace Game.StateMachine
{
    public class InitialState : GameState
    {
        public InitialState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
            nextState = gsm.drawPhase;
        }
    
        public override void InitializeNextState()
        {
            nextState = stateMachine.drawPhase;
        }

        public override void Tick()
        {
            base.Tick();base.Tick();
            if (TimeSinceEnter > 2)
            {
                stateMachine.ChangeState(NextState);
            }
        }

        public override void OnStateExit()
        {
            stateMachine.OnIntialPhaseExit.Raise();
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnInitialPhaseEnter.Raise();
        }
    }
}
        