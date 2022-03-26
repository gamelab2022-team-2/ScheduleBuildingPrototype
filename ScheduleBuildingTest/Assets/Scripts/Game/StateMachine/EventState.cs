using UnityEngine;

namespace Game.StateMachine
{
    /// <summary>
    /// Adds anxiety cards - if a certain choice is selected
    /// Adds motivation or grades - added by certain choice
    /// </summary>
    public class EventState : GameState
    {
        private GameObject eventPopUp;
        public EventState(GameStateMachine gsm, Player player) : base(gsm, player)
        {
            eventPopUp = stateMachine.eventCanvas;
        }

        public override void Tick()
        {
            base.Tick();
        }

        public override GameState NextState
        {
            get => stateMachine.GameOverCondition() ? stateMachine.gameOverState : EventOrDraw();
        }

        public GameState EventOrDraw()
        {
            if (GameManager.Instance.turn < 15)
                return stateMachine.newCardPhase;
            return stateMachine.drawPhase;
        }

        public override void InitializeNextState()
        {
            nextState = stateMachine.drawPhase;
        }

        public override void OnStateEnter()
        {
            stateMachine.OnEventPhaseEnter.Raise();
            if(IsEventTurn()) ActivateEvent();
            else
            {
                stateMachine.ChangeState(stateMachine.drawPhase);
            }
        }

        public override void OnStateExit()
        { 
            stateMachine.OnEventPhaseExit.Raise();
        }

        // if condition -> next phase (Draw Phase)


        public bool IsEventTurn()
        {
            return GameManager.Instance.turn % 2 == 0;
        }
    
    
        // toggle active of event UI
        public void ActivateEvent()
        {
            eventPopUp.SetActive(true);


        }

        /*public override void ApplyChoice(int selection)
        {
            EventChoice choice;
            Debug.Log("event state button pressed");

            // check which choice the user has made
            if (selection == 1)
            {
                choice = EventManager.instance.selectedEvent.choice1;
            }
            else
            {
                choice = EventManager.instance.selectedEvent.choice2;
            }

            // apply the changes that are contained in the choice selection

            player.grade.runtimeValue += choice.grade;
            player.motivation.runtimeValue += choice.motivation;

            //if (choice.card != null)
            //CardManager.instance.discardPile.Add(choice.card);
            //CardManager.instance.AddAnxiety(choice.addAnx);
            // CardManager.instance.RemoveAnxiety(choice.remAnx1); TO DO IMPLEMENT THIS
            // CardManager.instance.AddConnection(choice.connect); TO DO IMPLEMENT THIS
            //UpdateGauges();

            //EventManager.instance.MoveToUsed(EventManager.instance.selectedEvent);

            // if an event is unlocked by the current event add it to available event list in database
            //if (choice.unlockedEvent != null)
            //{
            //Database.instance.eventsDb.availableEvents.Add(choice.unlockedEvent);
            //Database.instance.eventsDb.eventsWithPrecondition.Remove(choice.unlockedEvent);
            //}*/

            //EndEventPhase();

            /*if (GameManager.Instance.turn < 15)
            {
                OpenCardSelector();
            }
        }*/

        private void OpenCardSelector()
        {
            stateMachine.ChangeState(stateMachine.newCardPhase);
        }




    }
}
