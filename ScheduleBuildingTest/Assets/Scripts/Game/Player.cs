using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using System;
using System.Reflection;
using DG.Tweening;
using Game;

public class Player : MonoBehaviour
{
    public CardSet deck = new CardSet();
    public CardSet discardPile = new CardSet();
    public CardSet hand = new CardSet();
    public CardSet allCards = new CardSet();

    public Transform handTransform;
    public GameObject gridObjectPrefab;

    // modifier variables (from events)
    public int motivationModifier = 0;
    public int gradeModifier = 0;
    

    public List<GridObject> gridObjects;

    public EventContainer eventContainer;

    public IntegerVariable motivation, grade, anxiety;

    public GameObject cardObject;
    public int Motivation => motivation.runtimeValue;
    public int Grade => grade.runtimeValue;
    public int Anxiety => anxiety.runtimeValue;

    public Schedule schedule;

    public void GetOpeningDeck()
    {
        AddCardToDeck(1);
        AddCardToDeck(1);
        AddCardToDeck(1);
        AddCardToDeck(2);
        AddCardToDeck(2);
        AddCardToDeck(2);
        AddCardToDeck(3);
        AddCardToDeck(3);
        AddCardToDeck(10);
        AddCardToDeck(10);
        deck.Shuffle();
    }

    public void DrawFromDeck()
    {
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
        DisplayCardsInHand();
    }
    
    //gets the 5 cards that should already be in the player's hand, and moves them from the offscreen "cardSleeve" to in front of the camera. also spawns the shapes on top of the cards
    public void DisplayCardsInHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            Card currCard = hand.GetAtIndex(i);
            //currCard.gameObject.transform.position = handTransform.GetChild(i).position + Vector3.up;
            currCard.transform.DOMove(handTransform.GetChild(i).position, 0.2f).SetDelay(i * 0.1f);
            var shape = Instantiate(gridObjectPrefab);

            shape.GetComponent<GridObject>().Initialize(currCard.shape,
                handTransform.GetChild(i).position + 2 * Vector3.up + Vector3.left*2 - Vector3.forward, currCard.shapeColor);
            //shapeSpawner.GetComponent<ShapeSpawner>().SpawnShape(_player.handGO.transform.GetChild(i).position, currCard.cardData.shape, currCard.cardData.shapeColor);
            gridObjects.Add(shape.GetComponent<GridObject>());
        }

        /*foreach (var card in hand.cards)
        {
            //card;
        }*/
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
        eventContainer.karma += choice.karmaValue;

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
        motivation.runtimeValue += i + motivationModifier;
        Debug.Log("MOTIVATION NOW IS "+motivation.runtimeValue);
    }

    public void ChangeAnxiety(int i)
    {
        Debug.Log("IN CHANGE ANXIETY WITH PARAM: " + i);
        anxiety.runtimeValue += i;
        Debug.Log("ANXIETY NOW IS " + anxiety.runtimeValue);
    }

    public void ChangeGrades(int i)
    {
        grade.runtimeValue += i + gradeModifier;
    }

    public void AddCard(int i)
    {
        /*GameObject newCardObject = Instantiate(cardObject);

        var cardComponent = newCardObject.GetComponent<Card>();*/

        if (i == 0) ChangeAnxiety(1);

        /*cardComponent.cardData = allCards.GetAtIndex(i).cardData;
        cardComponent.LoadData(cardComponent.cardData);
        cardObject.transform.position = new Vector3(-100, -100, -100);*/
        var cardData = allCards.GetAtIndex(i).cardData;
        var card = GameManager.Instance.cardSpawner.SpawnCard(cardData);
        discardPile.Add(card);
    }

    public void AddCardToDeck(int i)
    {
        /*GameObject newCardObject = Instantiate(cardObject);
        var cardComponent = newCardObject.GetComponent<Card>();
        cardComponent.cardData = allCards.GetAtIndex(i).cardData;
        cardComponent.LoadData(cardComponent.cardData);
        cardObject.transform.position = new Vector3(-100, -100, -100);
        deck.Add(cardComponent);*/

        var cardData = allCards.GetAtIndex(i).cardData;
        var card = GameManager.Instance.cardSpawner.SpawnCard(cardData);
        deck.Add(card);
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
            if (i == 0) ChangeAnxiety(-1);
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
        Debug.Log("block row " + i);
        schedule.BlockRow(i);
    }

    public void BlockColumn(int i)
    {
        schedule.BlockColumn(i);
    }

    public void BlockInRow(int i)
    {
        schedule.BlockInRow(i);
    }

    public void BlockInColumn(int i)
    {
        schedule.BlockInColumn(i);
    }

    public void SetMotivationModifier(int i)
    {
        motivationModifier = i;
    }

    public void SetGradeModifier(int i)
    {
        gradeModifier = i;
    }

    public void ResetModifiers()
    {
        gradeModifier = 0;
        motivationModifier = 0;
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
