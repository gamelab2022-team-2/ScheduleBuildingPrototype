using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using System;
using System.Reflection;
using Game;

public class Player : MonoBehaviour
{
    public CardSet deck = new CardSet();
    public CardSet discardPile = new CardSet();
    public CardSet hand = new CardSet();
    public CardSet allCards = new CardSet();

    public List<GridObject> gridObjects;

    public EventContainer eventContainer;

    public IntegerVariable motivation, grade;
    
    public GameObject handGO;

    public GameObject cardObject;
    public int Motivation => motivation.runtimeValue;
    public int Grade => grade.runtimeValue;

    public Schedule schedule;

    public void GetOpeningDeck()
    {
        AddCardToDeck(2);
        AddCardToDeck(2);
        AddCardToDeck(2);
        AddCardToDeck(3);
        AddCardToDeck(3);
        AddCardToDeck(3);
        AddCardToDeck(4);
        AddCardToDeck(4);
        AddCardToDeck(5);
        AddCardToDeck(5);
        deck.Shuffle();
    }

    public void DrawFromDeck()
    {
        Debug.Log("DECK CONTAINS:");
        foreach (Card c in deck.cards)
        {
            Debug.Log("   " + c.cardName);
        }
        while (hand.Count < 5)
        {

            if (deck.Count >= 1)
            {
                Card drawnCard = deck.Draw();
                
                if (drawnCard.type == CardType.STATUS)
                {
                    for (int m = 0; m < drawnCard.onDraw.Count; m++)
                    {
                        Type thisType = this.GetType();
                        MethodInfo theMethod = thisType
                            .GetMethod(drawnCard.onDraw[m]);
                        theMethod.Invoke(this, new object[] { drawnCard.onDrawParams[m] });
                    }
                    if (drawnCard.burnAfterUse)
                    {
                        Destroy(drawnCard.transform.gameObject);
                    }
                    else
                    {
                        discardPile.Add(drawnCard);
                    }
                }
                else
                    hand.Add(drawnCard);

            }
            else
            {

                DiscardPileReturnToDeck();

            }
        }

        GameManager.Instance.DisplayCardsInHand();
    }
    private void DiscardPileReturnToDeck()
    {
        while (discardPile.Count > 0)
        {
            Card card = discardPile.Draw();
            deck.Add(card);
        }
        deck.Shuffle();
    }


    public void ApplyHand()
    {
        Debug.Log("Calculating Resolution Values");
        
        for( int c = 0; c < hand.Count; c++)
        {
            Card resolvingCard = hand.GetAtIndex(c);
            Debug.Log("cards in Hand resolving");
            if (gridObjects[c].OnGrid())
            {

                Debug.Log("About to resolve card #" + c);
                for (int m = 0; m < resolvingCard.placedResolve.Count; m++)
                {
                    Type thisType = this.GetType();
                    MethodInfo theMethod = thisType
                        .GetMethod(resolvingCard.placedResolve[m]);
                    
                    theMethod.Invoke(this, new object[] { resolvingCard.placedResolveParams[m] });
                }
            }
            else
            {
                Debug.Log("About to resolve card #" + c);
                for (int m = 0; m < resolvingCard.unplacedResolve.Count; m++)
                {
                    Type thisType = this.GetType();
                    MethodInfo theMethod = thisType
                        .GetMethod(resolvingCard.unplacedResolve[m]);
                    theMethod.Invoke(this, new object[] { resolvingCard.unplacedResolveParams[m] });
                }
            }
        }
    }

    public void ApplyEventChoice(EventChoice choice)
    {
        Debug.Log("Calculating Choice Values");

        for (int m = 0; m < choice.choiceResolve.Count; m++)
        {
            Debug.Log("Get Method = " + choice.choiceResolve[m]);
            Type thisType = this.GetType();
            MethodInfo theMethod = thisType
            .GetMethod(choice.choiceResolve[m]);

            theMethod.Invoke(this, new object[] { choice.choiceParams[m] });
        }

    }
    

    // TODO: Implement this function on for the gameboard/schedule
  //  public bool PlaceCard(Card card,Vector2Int pos)
  //{
  //  return true;
  //}
 
   public void ChangeMotivation(int i)
    {
        Debug.Log("IN CHANGE MOTIVATION WITH PARAM: "+ i);
        motivation.runtimeValue += i;
        Debug.Log("MOTIVATION NOW IS "+motivation.runtimeValue);
    }

    public void ChangeGrades(int i)
    {
        grade.runtimeValue += i;
    }

    public void AddCard(int i)
    {

        
        GameObject newCardObject = Instantiate(cardObject);

        var cardComponent = newCardObject.GetComponent<Card>();
        cardComponent.cardData = allCards.GetAtIndex(i).cardData;
        cardComponent.LoadData(cardComponent.cardData);
        cardObject.transform.position = new Vector3(-100, -100, -100);
        discardPile.Add(cardComponent);


    }
    public void AddCardToDeck(int i)
    {


        GameObject newCardObject = Instantiate(cardObject);

        var cardComponent = newCardObject.GetComponent<Card>();
        cardComponent.cardData = allCards.GetAtIndex(i).cardData;
        cardComponent.LoadData(cardComponent.cardData);
        cardObject.transform.position = new Vector3(-100, -100, -100);
        deck.Add(cardComponent);


    }

    public void RemoveCard(int i)
    {
        bool found = false;
        int index = -1;
        for (int j = 0; j < discardPile.cards.Count; j++)
        {
            if (discardPile.GetAtIndex(j).cardId == i)
            {
                index = j;
                found = true;
            }

        }
        if (found)
        {
            Card toDelete = discardPile.GetAtIndex(index);
            discardPile.cards.RemoveAt(index);
            Destroy(toDelete.transform.gameObject);

        }
    }

    public void UnlockEvent(int eventId)
    {
        eventContainer.UnlockEvent(eventId);
    }

    public void BlockSpot(int i)
    {
        for (int j = 0; j < i; j++)
            schedule.BlockRandomSlot();
    }

    public void BlockRow(int i)
    {
        schedule.BlockRow(i);
    }

    public void BlockColumn(int i)
    {
        schedule.BlockColumn(i);
    }

    #region Discard Methods
    /// <summary>
    /// Discards cards from the schedule into the Discard set
    /// </summary>
    public void DiscardSchedule()
  {
    /*foreach (var card in schedule.cardsInSchedule)
    {
      discard.Add(card);
    }
    schedule.cardsInSchedule.Clear();*/
  }

    /// <summary>
    /// Discards cards from the Hand set into the Discard set
    /// </summary>
    public void DiscardHand()
    {
        GameManager.Instance.ReturnAllToSleeve();
        foreach (var card in hand.cards)
        {
            discardPile.Add(card);
        }
        hand.EmptyCardSet();

    }

    public void ClearShapes()
    {
        foreach (GridObject go in gridObjects)
            Destroy(go.transform.gameObject);
        gridObjects.Clear();  
    }
    #endregion


}
