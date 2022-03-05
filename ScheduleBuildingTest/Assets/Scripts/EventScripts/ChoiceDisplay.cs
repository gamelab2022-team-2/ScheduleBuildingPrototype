using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour
{
    public EventChoice choice;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image artImage;

    // When event canvas is setActive set all values to the correct selected event
    public void Start()
    {

        title.text = choice.title;
        description.text = choice.description;
        artImage = choice.art;
    }

}
