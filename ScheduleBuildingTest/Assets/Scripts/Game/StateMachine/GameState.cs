using System;
using UnityEngine;

namespace Game.StateMachine
{
    [Serializable]
    public abstract class GameState
    {
        protected GameStateMachine stateMachine;
        protected Player player;
        protected GameState nextState;
        protected float stateEnterTime = 0;

        public virtual GameState NextState => nextState;

        public float TimeSinceEnter => Time.time - stateEnterTime;
    
        public GameState(GameStateMachine gsm, Player p)
        {
            Debug.Log("Instantiating State: " + this);
            stateMachine = gsm;
            player = p;
        }

    
        public abstract void InitializeNextState();
    
        /// <summary>
        /// Code within this function of the current state will be called on Update.
        /// Will likely be used to animate the game.
        /// </summary>
        public virtual void Tick(){}

        /// <summary>
        /// Called when the current state is first entered, after exiting the previous state.
        /// </summary>
        public virtual void OnStateEnter()
        {
            stateEnterTime = Time.time;
        }

        /// <summary>
        /// Called when when exiting current state, before entering another.
        /// </summary>
        public virtual void OnStateExit()
        {
        
        }
    
        // TODO: make this more robust
        public virtual bool GameOverCondition()
        {
            return false;
        }

        public virtual void ApplyChoice(int selection)
        {
            Debug.Log("game state button pressed");
        }

    }
}
