using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CardSet hand, deck, discard;
  public GameBoard schedule;
  public IntegerVariable motivation, grade;
  public GameObject motUI, gradeUI;

  public Card DrawDeck()
  {
    return deck.Draw();
  }
  
  public void ReplenishDeck()
  {
    while(discard.Count > 0)
    {
      deck.Add(discard.Draw());  
    }
  }

    public void UpdateUI()
    {
        motUI.GetComponent<TMPro.TextMeshProUGUI>().text = motivation.ToString();
        gradeUI.GetComponent<TMPro.TextMeshProUGUI>().text = grade.ToString();
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
    foreach (var card in deck.cards)
    {
      discard.Add(card);
    }
    deck.cards.Clear();
  }
  #endregion
  
  
}
