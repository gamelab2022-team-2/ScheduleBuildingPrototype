using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour
{

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image artImage;

    public ChoiceDisplay choice1;
    public ChoiceDisplay choice2;

    // When event canvas is setActive set all values to the correct selected event
    public void OnEnable()
    {

        SetUI(Database.instance.getRandomEvent());
        
    }

    private void SetUI(Event e)
    {
        title.text = e.title;
        description.text = e.description;
        artImage = e.art;

        choice1.SetUI(e.choice1);
        choice2.SetUI(e.choice2);

    }

    
}
