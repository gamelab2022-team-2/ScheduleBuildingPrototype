using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    private GameObject _cardSleeve;
    public GameObject cardPrefab;


    public GameObject CardSleeve => _cardSleeve;

    public void Awake()
    {
        _cardSleeve = new GameObject("Card Sleeve");
        _cardSleeve.transform.position = new Vector3(-100, -100, -100);
    }

    public Card SpawnCard(CardData c)
    {
        GameObject card = Instantiate(cardPrefab, _cardSleeve.transform);
        card.name = c.cardName + " Card";
        var cardComponent = card.GetComponent<Card>();
        cardComponent.cardData = c;
        cardComponent.LoadData(c);
        return cardComponent;
    }
}
