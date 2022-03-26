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

        public override void OnStateExit()
        {
            stateMachine.OnIntialPhaseExit.Raise();
        }
    }
}
        