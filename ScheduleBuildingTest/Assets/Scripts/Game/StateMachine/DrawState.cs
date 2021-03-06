using UnityEngine;

namespace Game.StateMachine
{
    /// <summary>
    /// adds cards from the deck to the hand
    /// activates anxiety cards on the board if drawn
    /// </summary>
    public class DrawState : GameState
    {


        public DrawState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
        }
    
    
        // if condition -> next phase (Place State)
        public override void InitializeNextState()
        {
            nextState = stateMachine.placePhase;
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
            stateMachine.OnDrawPhaseEnter.Raise();
            GameManager.Instance.turn.runtimeValue += 1;
            Draw();
        }

        public override void OnStateExit() 
        {
            stateMachine.OnDrawPhaseExit.Raise();
            foreach (GridObject go in player.gridObjects)
            {
                go.allowedToMove = true;
            }
            base.OnStateExit();
        }

        public void Draw()
        {
            player.DrawFromDeck();
        }
    

    }
}
