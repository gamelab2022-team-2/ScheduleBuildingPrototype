using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardSleeve;
    public GameObject cardPrefab;


    public GameObject CardSleeve => cardSleeve;


    public Card SpawnCard(CardData c)
    {
        GameObject card = Instantiate(cardPrefab, cardSleeve.transform);
        var cardComponent = card.GetComponent<Card>();
        cardComponent.cardData = c;
        cardComponent.LoadData(c);
        card.name = cardComponent.cardName + " Card";
        return cardComponent;
    }
}
