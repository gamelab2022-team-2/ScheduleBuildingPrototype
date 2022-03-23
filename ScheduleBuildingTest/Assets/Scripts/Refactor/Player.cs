using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CardSet deck;
    public CardSet discardPile;
    public CardSet hand;
    public CardSet allCards;

    public IntegerVariable motivation, grade;

    public GameBoard schedule;

    public int Motivation => motivation.runtimeValue;
    public int Grade => grade.runtimeValue;

    public void CreateAllCards()
    {
        if(allCards == null)
        {
            allCards = gameObject.AddComponent<CardSet>();
        }
        foreach(Card c in Game.Instance.allCards)
        {
            allCards.Add(c);
        }
    }

    public void DrawFromDeck()
    {
        while (hand.Count < 5)
        {

            if (deck.Count >= 1)
            {
                Card drawnCard = deck.Draw();


                hand.Add(drawnCard);
                //drawnCard.inHand = true;
            }
            else
            {

                DiscardPileReturnToDeck();

            }

        }
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
        
        foreach(Card card in hand.cards)
        {
            Debug.Log("cards in Hand resolving");
            /*if (!card.inSchedule)
            {g
                motivation += card.inHandMotiv;
                CardManager.instance.AddAnxiety(card.anxiety);
                Debug.Log(card.anxiety + " added");
                UpdateGauges();
            }*/

            //TODO: Do we want to increase motivation when cards are in hand AND in the schedule?
            /*if (card.inSchedule)
            {
                grades += card.grades;
                motivation += card.motivation;
                UpdateGauges();
            }*/
        }
    }
    

    // TODO: Implement this function on for the gameboard/schedule
    public bool PlaceCard(Card card,Vector2Int pos)
  {
    return true;
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
        foreach (var card in hand.cards)
        {
            discardPile.Add(card);
        }
        hand.EmptyCardSet();
    }
    #endregion


}
