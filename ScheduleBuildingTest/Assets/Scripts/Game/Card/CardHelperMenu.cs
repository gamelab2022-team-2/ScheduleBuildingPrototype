using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardHelperMenu : MonoBehaviour
{
    private void OnMouseOver()
    {
        CardDescriptionPanel panel = FindObjectOfType<CardDescriptionPanel>();
        if (Input.GetMouseButtonDown(1))
        {
            CardData data = transform.GetComponentInParent<Card>().cardData;
            panel.ClickOnACard(data);
        }
        if (!Input.GetMouseButton(1))
        {
            panel.CloseThePanel();
        }
    }
    private void OnMouseExit()
    {
        CardDescriptionPanel panel = FindObjectOfType<CardDescriptionPanel>();
        panel.CloseThePanel();
    }
}
