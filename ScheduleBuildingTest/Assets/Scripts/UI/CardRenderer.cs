using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardRenderer : MonoBehaviour
{
    public CardData data;
    public TextMeshProUGUI title, inScheduleMot, inScheduleGrad, inHandMot, inHandAnx;
    public Image image;
    public Image cardImage;


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
            image.sprite = data.shapeImage;
            inScheduleMot.text = data.displayMotiv.ToString();
            inScheduleGrad.text = data.displayGrades.ToString();
            inHandAnx.text = data.displayAnx.ToString();
            inHandMot.text = data.displayMotivInHand.ToString();
            cardImage.color = data.cardColor;
            image.color = data.cardColor;
        }
    }
}
