using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public Deck deck;
    public Discard discard;
    public Transform[] cardSlots;
    public bool[] availableSlots;
    public static CardManager instance;
    public List<Card> cardsInHand;

    public void Awake()
    {
       if(instance == null)
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
            if (deck.cards.Count >= 1)
            {
                Card drawnCard = DrawCard();


                cardsInHand.Add(drawnCard);

                PlaceCard(drawnCard);
               

            }
            else
            {
                
                DiscardPileReturnToDeck();
                
            }

            if(deck.cards.Count == 0)
            {
                deck.gameObject.SetActive(false);
            }

        }
    }

    public void DiscardPhase()
    {
        while (cardsInHand.Count > 0)
        {
            Card cardMove = cardsInHand[0];
            cardMove.gameObject.SetActive(false);
            cardMove.transform.position = discard.gameObject.transform.position;

            if (!cardMove.inSchedule)
            {
                //RESOLVE CONSEQUENCE HERE : CALL METHOD FROM GAME MANAGER
            }


            cardsInHand.RemoveAt(0);
            discard.cards.Add(cardMove);
            discard.gameObject.SetActive(true);
        }

        for (int i = 0; i<availableSlots.Length; i++)
        {
            availableSlots[i] = true;
        }

        
    }

    public Card DrawCard()
    {

        Card drawnCard = deck.cards[0];
        drawnCard.inHand = true;

        drawnCard.gameObject.SetActive(true);
        deck.cards.RemoveAt(0);
        return drawnCard;



    }

    public void DiscardPileReturnToDeck()
    {
        while (discard.cards.Count > 0)
        {
            Card card = discard.cards[0];
            deck.cards.Add(card);
            discard.cards.RemoveAt(0);
        }
        discard.gameObject.SetActive(false);
        deck.gameObject.SetActive(true);
        deck.Shuffle();
    }

    public bool StatusCardCheck(Card cardToCheck)
    {
        if (cardToCheck.isStatus)
        {
            //RESOLVE STATUS CARD
            cardsInHand.Remove(cardToCheck);
            discard.cards.Add(cardToCheck); // OR DELETE CARD IF WE HAVE ONE TIME CARD
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
                cardToPlace.transform.position = cardSlots[i].position;
                availableSlots[i] = false;

                bool isStatus = StatusCardCheck(cardToPlace);
                if (isStatus)
                {
                    availableSlots[i] = true;
                }

                return;

            }
        }
    }

}
