using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CardSet hand, deck, discard;
  public GameBoard schedule;
  public int motivation, grade;

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

  public bool PlaceCard(Card card)
  {
    return true;
  }
 
  
}
