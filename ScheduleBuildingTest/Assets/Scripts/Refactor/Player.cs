using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CardSet hand, deck, discard;
  public GameBoard schedule;
  public int motivation, grade;

  public Card Draw()
  {
    return deck.Draw();
  }

  public bool PlaceCard(Card card)
  {
    return true;
  }
  
}
