using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card database", menuName = "Databases/Card Database")]

public class CardsDatabase : ScriptableObject
{

    public List<Cards> deck;
    public List<Cards> discardPile;
    public List<Cards> cardWithPrerequisite;
    public List<Cards> allCards;

}
