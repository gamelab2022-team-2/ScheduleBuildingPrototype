using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    public CardData data;
    public TextMeshProUGUI title, inSchedule, inHand;
    public Sprite image;

    public void Start()
    {
        UpdateCardDisplay();
    }
    public void UpdateCardDisplay()
    {
        data = GetComponent<Card>().cardData;
        if (data != null)
        {
            title.text = data.cardName;
            image = data.shapeImage;
        }
    }
}
