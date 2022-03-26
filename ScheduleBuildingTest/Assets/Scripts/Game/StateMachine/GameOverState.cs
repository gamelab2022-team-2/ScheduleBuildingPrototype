namespace Game.StateMachine
{
    public class GameOverState : GameState
    {
        public GameOverState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
        public override void InitializeNextState()
        {
            nextState = stateMachine.initialPhase;
        }

        public override void OnStateEnter()
        {
            stateMachine.OnGameOverStateEnter.Raise();
        }
    
    }
}
