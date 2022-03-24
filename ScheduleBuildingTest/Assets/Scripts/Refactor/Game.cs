using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Game : MonoBehaviour
{
    #region Singleton
    private static Game _instance;

    public static Game Instance
    {
        get { return _instance; }
    }

    private void Awake() 
    { 
        if (Instance != null && Instance != this) { Destroy(this); } 
        else { _instance = this; } 
    }

    #endregion Singleton

    [SerializeField]
    private Player _player;
    [SerializeField]
    private GameBoard schedule;

    public List<CardData> allCardData;

    public GameObject cardgo;
    private GameObject sleeve;

    public GameObject shapeSpawner;


    public int turn;

    void Start()
    {
        turn = 0;
        GenerateCardSets();
    }
    
    public void GenerateCardSets()
    {
        sleeve = new GameObject("Card Sleeve");
        sleeve.transform.position = new Vector3(-100, -100, -100);

        foreach (CardData c in allCardData)
        {
            GameObject card = Instantiate(cardgo, sleeve.transform);
            card.name = c.description + " Card";
            var cardComponent = card.GetComponent<Card>();
            cardComponent.cardData = c;
            cardComponent.LoadData(c);
            _player.allCards.Add(cardComponent);
        }

        _player.GetOpeningDeck();
    }

    public void DisplayCardsInHand()
    {
        for (int i = 0; i < _player.hand.Count; i++)
        {
            Card currCard = _player.hand.GetAtIndex(i);
            currCard.gameObject.transform.position = _player.handGO.transform.GetChild(i).position;
            shapeSpawner.GetComponent<ShapeSpawner>().SpawnShape(_player.handGO.transform.GetChild(i).position, currCard.cardData.shape, currCard.cardData.shapeColor);
        }
    }
    public void ReturnAllToSleeve() 
    {
        for (int i = 0; i < _player.hand.Count; i++)
        {
            _player.hand.GetAtIndex(i).gameObject.transform.position = sleeve.transform.position;
        }
        shapeSpawner.GetComponent<ShapeSpawner>().Clear();
    }


    /*public void ActivateEvent()
    {
        
        if (turn % 2 == 0)
        {
            eventCanvas.SetActive(true);
            

        }
        else
        {
            
            phase = 0;
        }

        

    }*/

    /*private void UpdateGauges()
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
    }*/


    /*public void EndPlacePhase()
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

    }*/


}
