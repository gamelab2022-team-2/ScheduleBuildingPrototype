using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    
    public int turn;
    
    // Phase State Machine
    private GameStateMachine gsm;


    // Start is called before the first frame update
    void Start()
    {
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 0 = drawphase, 1 = placephase, 2 = resolutionphase, 3 = discardphase, 4 = eventphase  
        switch (phase)
        {
            //draw
            // case 0:
            //     turn++;
            //     CardManager.instance.DrawPhase();
            //     phase++;
            //     break;
           //place
            case 1:
                
                break;
            // resolution
            case 2:
                ResolutionPhase();
                Debug.Log("resolution ended");
                break;
            // discard
            case 3:
                CardManager.instance.DiscardPhase();
                phase++;
                break;
            //event
            case 4:
                ActivateEvent();  
                Debug.Log("turn = " + turn);
                break;
        }

    }

    

    public void ActivateEvent()
    {
        
        if (turn % 2 == 0)
        {
            eventCanvas.SetActive(true);
            

        }
        else
        {
            
            phase = 0;
        }

        

    }

    private void UpdateGauges()
    {
        motivText.text = motivation.ToString();
        gradeText.text = grades.ToString();
        UpdateGaugeColor();
    }

    private void UpdateGaugeColor()
    {
        if (motivation < 30)
        {
            motivText.color = Color.red;
        }
        else if (motivation >= 30 && motivation <= 50)
        {
            motivText.color = Color.yellow;
        }
        else if (motivation > 50)
        {
            motivText.color = Color.green;
        }

        if (grades < 50)
        {
            gradeText.color = Color.red;
        }
        else if (grades >= 50 && grades < 70)
        {
            gradeText.color = Color.yellow;
        }
        else if (grades >= 70)
        {
            gradeText.color = Color.green;
        }
    }

    private void ResolutionPhase()
    {
        Debug.Log("Resolution Started");
        foreach(Card card in CardManager.instance.cardsInHand)
        {
            Debug.Log("cards in Hand resolving");
            if (!card.inSchedule)
            {
                motivation += card.inHandMotiv;
                CardManager.instance.AddAnxiety(card.anxiety);
                Debug.Log(card.anxiety + " added");
                UpdateGauges();
            }


            if (card.inSchedule)
            {
                grades += card.grades;
                motivation += card.motivation;
                UpdateGauges();
            }
        }



        phase++;

    }
    
    public void EndPlacePhase()
    {
        Debug.Log("Place Phase Ended");
        if(phase == 1)
        {
            phase++;

        }
            
    }

    // TEMPORARY METHOD TO END EVENT PHASE
    public void EndEventPhase()
    {
        eventCanvas.SetActive(false);
        phase = 0;
    }

    public void ApplyChoice(int selection)
    {
        EventChoice choice;

        // check which choice the user has made
        if (selection == 1)
        {
           choice  = EventManager.instance.selectedEvent.choice1;
        }
        else
        {
            choice = EventManager.instance.selectedEvent.choice2;
        }

        // apply the changes that are contained in the choice selection
        grades += choice.grade;
        motivation += choice.motivation;

        if(choice.card != null)
            CardManager.instance.discardPile.Add(choice.card);
        CardManager.instance.AddAnxiety(choice.addAnx);
        // CardManager.instance.RemoveAnxiety(choice.remAnx1); TO DO IMPLEMENT THIS
        // CardManager.instance.AddConnection(choice.connect); TO DO IMPLEMENT THIS
        UpdateGauges();

        // remove the event from the available event list in the database so user doesn't get same event twice
        Database.instance.events.availableEvents.Remove(EventManager.instance.selectedEvent);
        Database.instance.events.usedEvents.Add(EventManager.instance.selectedEvent);

        // if an event is unlocked by the current event add it to available event list in database
        if(choice.unlockedEvent != null)
            Database.instance.events.availableEvents.Add(choice.unlockedEvent);

        EndEventPhase();

    }


}
