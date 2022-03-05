using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    // deck and pile object
    public GameObject deck;
    public GameObject discard;

    // card lists
    public List<Card> cardsInHand;
    public GameObject anxietyCardPrefab;
    public List<Card> deckCards;
    public List<Card> discardPile;

    public Transform[] cardSlots;
    public bool[] availableSlots;
    public static CardManager instance;


    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
            return;
        }
    }

    public void Update()
    {

    }


    public void DrawPhase()
    {
        while (cardsInHand.Count < 5)
        {
            
            if (deckCards.Count >= 1)
            {
                
                Card drawnCard = DrawCard();


                cardsInHand.Add(drawnCard);
                drawnCard.inHand = true;

                PlaceCard(drawnCard);
          
                

            }
            else
            {

                DiscardPileReturnToDeck();

            }

            if (deckCards.Count == 0)
            {
                deck.SetActive(false);
            }
            
        }
        
    }



    public void DiscardPhase()
    {
        while (cardsInHand.Count > 0)
        {
            Card cardMove = cardsInHand[0];
            cardMove.gameObject.SetActive(false);
            cardMove.transform.position = discard.transform.position;
            cardMove.inHand = false;
            cardMove.inSchedule = false;

            cardsInHand.RemoveAt(0);
            discardPile.Add(cardMove);
            discard.SetActive(true);
        }

        for (int i = 0; i<availableSlots.Length; i++)
        {
            availableSlots[i] = true;
        }

        
    }

    private Card DrawCard()
    {

        Card drawnCard = deckCards[0];
        drawnCard.inHand = true;

        drawnCard.gameObject.SetActive(true);
        deckCards.RemoveAt(0);
        return drawnCard;



    }

    private void DiscardPileReturnToDeck()
    {
        while (discardPile.Count > 0)
        {
            Card card = discardPile[0];
            deckCards.Add(card);
            card.transform.position = deck.transform.position;
            discardPile.RemoveAt(0);
        }
        discard.gameObject.SetActive(false);
        deck.gameObject.SetActive(true);
        Shuffle(deckCards);
    }


    public bool StatusCardCheck(Card cardToCheck)
    {
        if (cardToCheck.isStatus)
        {
            //RESOLVE STATUS CARD
            Debug.Log("Status Card resolved");
            cardsInHand.Remove(cardToCheck);
            discardPile.Add(cardToCheck); // OR DELETE CARD IF WE HAVE ONE TIME CARD
            cardToCheck.gameObject.SetActive(false);
            return true;
        }

        return false;
    }

    public void PlaceCard(Card cardToPlace)
    {
        for (int i = 0; i < cardSlots.Length; i++)
        {
            if (availableSlots[i] == true)
            {
                StartCoroutine(MoveCard(cardToPlace, i));
                
                availableSlots[i] = false;

                bool isStatus = StatusCardCheck(cardToPlace);
                if (isStatus)
                {
                    availableSlots[i] = true;
                    // start status card coroutine?
                }

                return;

            }
        }
    }

    public void AddAnxiety(int num)
    {
        for(int i=0; i<num; i++)
        {
            AddAnx();
        }
    }

    private void AddAnx()
    {
        discardPile.Add(Instantiate(anxietyCardPrefab, CardManager.instance.transform).GetComponent<Card>());

    }

    public void Shuffle(List<Card> cards)
    {
        var rnd = new System.Random();

        for (int i = 0; i < cards.Count; i++)
        {
            int k = rnd.Next(0, i);
            Card value = cards[k];
            cards[k] = cards[i];
            cards[i] = value;
        }

    }

    IEnumerator MoveCard(Card cardToMove, int i)
    {
        float moveDuration = 1.0f;
        float t = 0.0f;
        Vector3 startPos = cardToMove.gameObject.transform.position;
        Vector3 endPos = cardSlots[i].position;

        while (t < moveDuration)
        {
            t += Time.deltaTime * (Time.timeScale / moveDuration);
            cardToMove.transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return 0;
        }  
    }

}
