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
    public Sprite image;
    public Color cardColor;

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
            inScheduleMot.text = data.displayMotiv.ToString();
            inScheduleGrad.text = data.displayGrades.ToString();
            inHandAnx.text = data.displayAnx.ToString();
            inHandMot.text = data.displayMotivInHand.ToString();
        }
    }
}
