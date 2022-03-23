using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSet : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public int Count => cards.Count;
    public void Add(Card card) => cards.Add(card);

    public Card Draw() 
    { 
        var drawn = cards[0]; 
        cards.RemoveAt(0); 
        return drawn; 
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

    public void EmptyCardSet()
    {
        cards.Clear();
    }
    
}
