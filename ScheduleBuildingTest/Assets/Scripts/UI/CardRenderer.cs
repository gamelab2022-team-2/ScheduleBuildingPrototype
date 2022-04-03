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
    public Sprite anxietyCard, connectionCard, cardImageSprite;


    public void Start()
    {
        UpdateCardDisplay();
    }
    public void UpdateCardDisplay()
    {
        if (GetComponent<Card>())
            data = GetComponent<Card>().cardData;
        else data = null;
        if (data != null)
        {
            if(data.type == CardType.STATUS)
            {
                title.gameObject.SetActive(false);
                inScheduleGrad.gameObject.SetActive(false);
                inScheduleMot.gameObject.SetActive(false);
                inHandAnx.gameObject.SetActive(false);
                inHandMot.gameObject.SetActive(false);
                image.gameObject.SetActive(false);

                if(data.cardName == "Anxiety")
                {
                    cardImage.sprite = anxietyCard;
                }
                else if (data.cardName == "Connection")
                {
                    cardImage.sprite = connectionCard;
                }
            }
            else
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
    public void UpdateCardDisplay(CardData data)
    {
        if (data != null)
        {
            if (data.type == CardType.STATUS)
            {
                title.gameObject.SetActive(false);
                inScheduleGrad.gameObject.SetActive(false);
                inScheduleMot.gameObject.SetActive(false);
                inHandAnx.gameObject.SetActive(false);
                inHandMot.gameObject.SetActive(false);
                image.gameObject.SetActive(false);

                if (data.cardName == "Anxiety")
                {
                    cardImage.sprite = anxietyCard;
                }
                else if (data.cardName == "Connection")
                {
                    cardImage.sprite = connectionCard;
                }
            }
            else
            {
                title.text = data.cardName;
                image.sprite = data.shapeImage;
                inScheduleMot.text = data.displayMotiv.ToString();
                inScheduleGrad.text = data.displayGrades.ToString();
                inHandAnx.text = data.displayAnx.ToString();
                inHandMot.text = data.displayMotivInHand.ToString();
                cardImage.color = data.cardColor;
                cardImage.sprite = cardImageSprite;
                image.color = data.cardColor;
            }

        }
    }
}
