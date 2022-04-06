using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardSleeve;
    public GameObject cardPrefab;


    public GameObject CardSleeve => cardSleeve;


    public Card SpawnCard(CardData c)
    {
        GameObject card = Instantiate(cardPrefab, cardSleeve.transform);
        //card.transform.DOScale(Vector3.one * 0.5f, 0.1f);
        var cardComponent = card.GetComponent<Card>();
        cardComponent.cardData = c;
        cardComponent.LoadData(c);
        card.name = cardComponent.cardName + " Card";
        return cardComponent;
    }
}
