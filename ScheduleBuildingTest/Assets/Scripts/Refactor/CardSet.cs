using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour
{
    public List<Card> cards;

    public Card Draw()
    {
        return cards[0];
    }
    
    public void Shuffle(){}
    public void Insert(Card card) => cards.Add(card);

    public void GetValues()
    {
        // To be used when a set (ex: Hand) needs to "resolve" at the end of the turn
        // For each card still in the set, return some value to be applied
    }

    
}
