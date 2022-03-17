using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card database", menuName = "Databases/Card Database")]

public class CardsDatabase : ScriptableObject
{

    public CardSet deck;
    public CardSet discardPile;
    public CardSet allCards;

    public void ReinitializeCardsDb()
    {
        // TO BE ADDED WHEN CARDS ALL DONE
    }

}
