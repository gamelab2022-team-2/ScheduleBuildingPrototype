using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI buttonText;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = Color.white;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = Color.black;
    }
}
