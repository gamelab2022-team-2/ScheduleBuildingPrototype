using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Card Variables
    public List<Card> cardStock;
    

    // Phase variables
    public int phase; // 0 = drawphase, 1 = placephase, 2 = resolutionphase, 3 = discardphase, 4 = eventphase  
    public int turn;

    // gauge variables
    public int motivation;
    public int grades;
    public TextMeshProUGUI motivText;
    public TextMeshProUGUI gradeText;

    // event variables
    public GameObject eventCanvas;
    public List<Event> eventList;


    // Start is called before the first frame update
    void Start()
    {
        // initialize turn and phase
        phase = 0;
        turn = 0;
    }

    // Update is called once per frame
    void Update()
    {
   
        switch (phase)
        {
            case 0:
                CardManager.instance.DrawPhase();
                phase++;
                break;
            case 1:
                
                break;
            case 2:
                ResolutionPhase();
                Debug.Log("resolution ended");
                break;
            case 3:
                CardManager.instance.DiscardPhase();
                phase++;
                break;
            case 4:
                ActivateEvent();
                turn++;
                break;
        }

    }

    

    public void ActivateEvent()
    {
        Debug.Log("event in event list = " + eventList.Count);
        // Event activeEvent = eventList[Random.Range(0, eventList.Count)];

        if (turn % 2 == 0)
        {
            eventCanvas.SetActive(true);

            
        }
            

        
    }

    private void updateGauges()
    {
        motivText.text = motivation.ToString();
        gradeText.text = grades.ToString();
        updateGaugeColor();
    }

    private void updateGaugeColor()
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
                updateGauges();
            }


            if (card.inSchedule)
            {
                grades += card.grades;
                motivation += card.motivation;
                updateGauges();
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


}
