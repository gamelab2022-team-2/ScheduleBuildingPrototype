using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    public void Start()
    {
        Shuffle();
    }

    public void Update()
    {

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



}
