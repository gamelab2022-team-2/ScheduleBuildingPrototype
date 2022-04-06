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
    public Sprite[] spriteList;
    public TextMeshProUGUI inScheduleIndicator, inHandIndicator;


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
            if (data.type == CardType.STATUS)
            {
                title.gameObject.SetActive(false);
                inScheduleGrad.gameObject.SetActive(false);
                inScheduleMot.gameObject.SetActive(false);
                inHandAnx.gameObject.SetActive(false);
                inHandMot.gameObject.SetActive(false);
                image.gameObject.SetActive(false);
                inScheduleIndicator.gameObject.SetActive(false);
                inHandIndicator.gameObject.SetActive(false);

                cardImage.sprite = spriteList[data.cardArtIndex];
            }
            else
            {
                title.text = data.cardName;
                image.sprite = data.shapeImage;
                if (data.topLeftValue == 0) inScheduleMot.text = " ";
                else
                    inScheduleMot.text = data.topLeftValue.ToString();
                if (data.bottomLeftValue == 0) inScheduleGrad.text = " ";
                else
                    inScheduleGrad.text = data.bottomLeftValue.ToString();
                if (data.bottomRightValue == 0) inHandAnx.text = " ";
                else
                    inHandAnx.text = data.bottomRightValue.ToString();
                if (data.topRightValue == 0) inHandMot.text = " ";
                else
                    inHandMot.text = data.topRightValue.ToString();
                cardImage.color = data.cardColor;
                cardImage.sprite = spriteList[data.cardArtIndex];
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

                cardImage.sprite = spriteList[data.cardArtIndex];
            }
            else
            {
                title.text = data.cardName;
                image.sprite = data.shapeImage;
                if (data.topLeftValue == 0) inScheduleMot.text = " ";
                else
                    inScheduleMot.text = data.topLeftValue.ToString();
                if (data.bottomLeftValue == 0) inScheduleGrad.text = " ";
                else
                    inScheduleGrad.text = data.bottomLeftValue.ToString();
                if (data.bottomRightValue == 0) inHandAnx.text = " ";
                else
                    inHandAnx.text = data.bottomRightValue.ToString();
                if (data.topRightValue == 0) inHandMot.text = " ";
                else
                    inHandMot.text = data.topRightValue.ToString();
                cardImage.color = data.cardColor;
                cardImage.sprite = spriteList[data.cardArtIndex];
                image.color = data.cardColor;
            }

        }
    }
}


