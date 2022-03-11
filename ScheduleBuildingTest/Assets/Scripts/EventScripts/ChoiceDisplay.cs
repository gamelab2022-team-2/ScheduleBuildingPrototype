using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceDisplay : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image artImage;


    public void SetUI(EventChoice e)
    {
        title.text = e.title;
        description.text = e.description;

    }

}
