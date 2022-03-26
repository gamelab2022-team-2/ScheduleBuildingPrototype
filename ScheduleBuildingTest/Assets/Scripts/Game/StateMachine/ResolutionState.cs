using UnityEngine;

namespace Game.StateMachine
{
    /// <summary>
    /// Adds anxiety cards - if cards are not played
    /// Adds motivation or grades - added by certain choice
    /// </summary>
    public class ResolutionState : GameState
    {
        public ResolutionState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
    
        public override void InitializeNextState()
        {
            nextState = stateMachine.discardPhase;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            stateMachine.OnResolutionPhaseEnter.Raise();
            foreach (GridObject go in player.gridObjects)
            {
                go.allowedToMove = false;
            }
            ResolutionPhase();
        }

        public override void Tick()
        {
        
            base.Tick();
            if (TimeSinceEnter > 2)
            {
                stateMachine.ChangeState(NextState);
            }
        }
    
        /// <summary>
        ///  For each card still in the player's hand after the placement phase,
        /// </summary>
        private void ResolutionPhase()
        {
            Debug.Log("Resolution Started");

            player.ApplyHand();

            Debug.Log("cards in Hand resolving");

        }

        public override void OnStateExit()
        {
            stateMachine.OnResolutionPhaseExit.Raise();
        }

        /// <summary>
        /// Check if a Game Over Condition has been met.
        /// </summary>
        /// <returns>True if player's motivation is less than or equal to 0, otherwise returns false.</returns>
        public override bool GameOverCondition()
        {
            if (player.motivation.runtimeValue <= 0) return true;
            return false;
        }
    
        // if condition -> next phase (Game Over)
        // if condition -> next phase (Discard State)
    }
}
