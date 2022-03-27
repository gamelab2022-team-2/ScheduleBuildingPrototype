using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    public CardData data;
    public TextMeshPro title, inSchedule, inHand;
    public Image image;
    
    public void UpdateCardDisplay()
    {
        data = GetComponent<Card>().cardData;
        if (data != null)
        {
            title.text = data.cardName;
            inSchedule.text = data.cardDescription;
            inHand.text = data.cardId.ToString();
        }
    }
}
