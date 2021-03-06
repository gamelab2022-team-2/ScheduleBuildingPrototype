using ScriptableObjects;
using UnityEngine;

namespace Game.StateMachine
{
    public class GameStateMachine : MonoBehaviour
    {
        [Header("Fields")] 
        public Player player;
        public GameObject eventCanvas;
        public GameObject newCardCanvas;
        public StringVariable currentStateString;
    
        [Header("Current State")] 
        public GameState currentState;
    
        [Header("Game States")] 
        public InitialState initialPhase;
        public DrawState drawPhase;
        public PlaceState placePhase;
        public ResolutionState resolutionPhase;
        public DiscardState discardPhase;
        public EventState eventPhase;
        public NewCardState newCardPhase;
        public GameOverState gameOverState;
        public WinState winState;

        [Header("GameEvents")] 
        public GameEvent changeStateEvent;

        [Header("Game State Events")] 
        public GameEvent OnInitialPhaseEnter;
        public GameEvent OnIntialPhaseExit;
        public GameEvent OnDrawPhaseEnter, OnDrawPhaseExit;
        public GameEvent OnPlacePhaseEnter, OnPlacePhaseExit;
        public GameEvent OnResolutionPhaseEnter, OnResolutionPhaseExit;
        public GameEvent OnDiscardPhaseEnter, OnDiscardPhaseExit;
        public GameEvent OnEventPhaseEnter, OnEventPhaseExit;
        public GameEvent OnNewCardPhaseEnter, OnNewCardPhaseExit;
        public GameEvent OnGameOverStateEnter, GameOverStateExit;
        public GameEvent OnWinStateEnter, OnWinStateExit;
  

        public void Awake()
        {
            if(!player) player = GetComponent<Player>();
        
            initialPhase = new InitialState(this, player);
            drawPhase = new DrawState(this, player);
            placePhase = new PlaceState(this, player);
            resolutionPhase = new ResolutionState(this, player);
            discardPhase = new DiscardState(this, player);
            eventPhase = new EventState(this, player);
            newCardPhase = new NewCardState(this, player);
            gameOverState = new GameOverState(this, player);
            winState = new WinState(this, player);
        
            initialPhase.InitializeNextState();
            drawPhase.InitializeNextState();
            placePhase.InitializeNextState();
            resolutionPhase.InitializeNextState();
            discardPhase.InitializeNextState();
            eventPhase.InitializeNextState();
            newCardPhase.InitializeNextState();
            gameOverState.InitializeNextState();
            winState.InitializeNextState();

        
            currentState = initialPhase;
            currentState.OnStateEnter();
        
        }

        public void Update()
        {
        
            currentState.Tick();
            //Debug.Log("State Time: " + currentState.TimeSinceEnter);
        }

    
        public void ChangeState(GameState state)
        {
            currentState.OnStateExit();
            currentState = state;
            currentStateString.runtimeValue = currentState.GetType().ToString();
            changeStateEvent.Raise();
            currentState.OnStateEnter();
        }
    
        public void ButtonPress(int button)
        {
            currentState.ApplyChoice(button);
        }


        public void NextState()
        {
            ChangeState(currentState.NextState);
        }


        public bool GameOverCondition()
        {
            return player.motivation.runtimeValue <= 0;
        }

    }
}
