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
    public CardAnimationController cardAnimationController;

    public GameObject gridObjectPrefab;

    // modifier variables (from events)
    public int motivationModifier = 0;
    public int gradeModifier = 0;

    public GameObject submitButton;

    public List<GridObject> gridObjects;

    public EventContainer eventContainer;

    public IntegerVariable motivation, grade, anxiety;

    public int Motivation => motivation.runtimeValue;
    public int Grade => grade.runtimeValue;
    public int Anxiety => anxiety.runtimeValue;

    public Schedule schedule;

    public AudioManager am;

    private List<GameObject> cardsToDestroy;

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
        cardsToDestroy = new List<GameObject>();
        int drawCount = 0;
        Sequence sequence = DOTween.Sequence();

        while (hand.Count < 5)
        {

            if (deck.Count >= 1)
            {
                Card drawnCard = deck.Draw();
                sequence.AppendCallback(PlayDrawSound);
                sequence.Append(cardAnimationController.AnimateDraw(drawnCard, hand.Count));
                drawCount += 1;


                if (drawnCard.type == CardType.STATUS)
                {
                    for (int m = 0; m < drawnCard.onDraw.Count; m++)
                    {
                        Type thisType = this.GetType();
                        if (drawnCard.onDraw[m].Equals("BlockSpot")) {
                            sequence.AppendCallback(BlockASpot);
                        }
                        else { 
                        MethodInfo theMethod = thisType
                            .GetMethod(drawnCard.onDraw[m]);
                        theMethod.Invoke(this, new object[] { drawnCard.onDrawParams[m] });
                        }
                    }
                    if (drawnCard.burnAfterUse)
                    {
                        //TODO: destroy the card after it animates
                        //Destroy(drawnCard.transform.gameObject);
                        cardsToDestroy.Add(drawnCard.gameObject);
                        
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
                sequence.Append(DiscardPileReturnToDeck());
            }
        }
        for(int i = 0; i<cardsToDestroy.Count;i++) sequence.AppendCallback(DestroyACard);
        sequence.AppendCallback(DisplayCardsInHand);
        sequence.AppendCallback(ActivateButton);

    }

    //TODO: Extract this functionality into a new "Card Animation Controller" class and flesh it out more
    //gets the 5 cards that should already be in the player's hand, and moves them from the offscreen "cardSleeve" to in front of the camera. also spawns the shapes on top of the cards
    public void DisplayCardsInHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {

            Card currCard = hand.GetAtIndex(i);
            //currCard.gameObject.transform.position = handTransform.GetChild(i).position + Vector3.up;;
            float w = currCard.shape[0] - '0';
            float h = currCard.shape[1] - '0';
            //TODO: Move this gridObject generation into another class and only call it when clicking or hovering over a card in the hand
            var shape = Instantiate(gridObjectPrefab);

            shape.GetComponent<GridObject>().Initialize(currCard.shape,
                handTransform.GetChild(i).position + ((3f-h)/2f + 1f) * Vector3.up + Vector3.left * (w-1f) - Vector3.forward, currCard.shapeColor);
            //shapeSpawner.GetComponent<ShapeSpawner>().SpawnShape(_player.handGO.transform.GetChild(i).position, currCard.cardData.shape, currCard.cardData.shapeColor);
            gridObjects.Add(shape.GetComponent<GridObject>());
        }

        foreach (GridObject g in gridObjects) g.allowedToMove = true;

        /*foreach (var card in hand.cards)
        {
            //card;
        }*/
    }


    private Tween DiscardPileReturnToDeck()
    {
        Sequence sequence = DOTween.Sequence();
        while (discardPile.Count > 0)
        {
            Card card = discardPile.Draw();
            deck.Add(card);
            sequence.Append(cardAnimationController.ToDeck(card));
        }
        deck.Shuffle();
        foreach (var card in deck.cards)
        {
            sequence.Append(cardAnimationController.Shuffle(card));
        }

        return sequence;
    }

    /// <summary>
    /// Discards cards from the Hand set into the Discard set
    /// </summary>
    public void DiscardHand()
    {
        Sequence sequence = DOTween.Sequence();
        foreach (var card in hand.cards)
        {
            sequence.Append(cardAnimationController.ToDiscard(card));
            discardPile.Add(card);
        }
        hand.EmptyCardSet();
    }


    public void ApplyHand()
    {
        Debug.Log("Calculating Resolution Values");

        for (int c = 0; c < hand.Count; c++)
        {
            Card resolvingCard = hand.GetAtIndex(c);
            Debug.Log("cards in Hand resolving");
            if (gridObjects[c].OnGrid())
            {

                Debug.Log("About to resolve card #" + c);
                for (int m = 0; m < resolvingCard.placedResolve.Count; m++)
                {
                    Type thisType = GetType();
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
        Debug.Log("IN CHANGE MOTIVATION WITH PARAM: " + i);
        motivation.runtimeValue += i + motivationModifier;
        Debug.Log("MOTIVATION NOW IS " + motivation.runtimeValue);
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
        cardAnimationController.ToDiscard(card);
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
        cardAnimationController.ToDeck(card);
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
    public void BlockASpot()
    {
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

    public void ClearShapes()
    {
        foreach (GridObject go in gridObjects)
            Destroy(go.transform.gameObject);
        gridObjects.Clear();
    }

    public void DestroyACard()
    {
        if (cardsToDestroy[0] != null)
        {
            Destroy(cardsToDestroy[0]);
            cardsToDestroy.RemoveAt(0);
        }
    }
    public void ActivateButton()
    {
        submitButton.SetActive(true);
    }
    public void PlayDrawSound()
    {
        float rand = UnityEngine.Random.Range(0f,1f);
        if (rand < 0.5f)
            am.PlaySingleSound("CardDeal");
        else
            am.PlaySingleSound("Discard");
    }

}
