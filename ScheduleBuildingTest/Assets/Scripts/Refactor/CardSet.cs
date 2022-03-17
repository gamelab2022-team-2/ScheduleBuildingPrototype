using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour
{
    public List<Card> cards;

    public Card Draw()
    {
        // NOTE card must be removed from deck and added to next cardset ( card must move, not stay in both cardsets)
        return cards[0];
    }
    
    public void Shuffle()
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
    public void Insert(Card card) => cards.Add(card);

    public void GetValues()
    {
        // To be used when a set (ex: Hand) needs to "resolve" at the end of the turn
        // For each card still in the set, return some value to be applied
    }

    
}
