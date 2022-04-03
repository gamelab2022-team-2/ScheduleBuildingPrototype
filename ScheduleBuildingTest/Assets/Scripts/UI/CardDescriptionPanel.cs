using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardDescriptionPanel : MonoBehaviour
{
    public GameObject panel;
    public TextMeshProUGUI onPlayDescription;
    public TextMeshProUGUI unplayedDescription;
    public TextMeshProUGUI statusDescription;
    public TextMeshProUGUI flavorText;

    // Start is called before the first frame update
    public void ClickOnACard(CardData data)
    {
        panel.SetActive(true);
        GetComponentInChildren<CardRenderer>().UpdateCardDisplay(data);
        GameObject child = transform.GetChild(0).gameObject;
        if (data.type == CardType.STATUS)
        {
            onPlayDescription.transform.parent.transform.parent.gameObject.SetActive(false);
            unplayedDescription.transform.parent.transform.parent.gameObject.SetActive(false);
            statusDescription.transform.parent.transform.parent.gameObject.SetActive(true);
        }
        else
        {
            onPlayDescription.transform.parent.transform.parent.gameObject.SetActive(true);
            unplayedDescription.transform.parent.transform.parent.gameObject.SetActive(true);
            statusDescription.transform.parent.transform.parent.gameObject.SetActive(false);
        }
        onPlayDescription.text = data.onPlayDescription;
        unplayedDescription.text = data.unplayedDescription;
        statusDescription.text = data.unplayedDescription;
        flavorText.text = data.flavorText;

    }
    public void CloseThePanel()
    {
        panel.SetActive(false);
    }
}
