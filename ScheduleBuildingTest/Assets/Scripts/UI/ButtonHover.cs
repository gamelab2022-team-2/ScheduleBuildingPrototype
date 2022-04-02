using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;
    private Color32 pink = new Color32(247, 47, 133, 255);
    private Color32 yellow = new Color32(255, 236, 31, 255);

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = yellow;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = pink;
    }

}
