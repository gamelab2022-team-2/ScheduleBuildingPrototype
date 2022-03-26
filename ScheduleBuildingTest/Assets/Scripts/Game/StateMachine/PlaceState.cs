namespace Game.StateMachine
{
    public class PlaceState : GameState
    {
        public PlaceState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
    
        public override void InitializeNextState()
        {
            nextState = stateMachine.resolutionPhase;
        }
    
        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnPlacePhaseEnter.Raise();
        }
        // if condition -> next phase (Resolution Phase)

        public override void OnStateExit()
        {
            stateMachine.OnPlacePhaseExit.Raise();
        }
    }
}
