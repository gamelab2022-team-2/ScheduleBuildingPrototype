using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour
{

    // this class just fills the event canvas with the values of a selected event
    public Event selectedEvent;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image artImage;

    public EventContainer eventContainer;

    public ChoiceDisplay choice1;
    public ChoiceDisplay choice2;

    public void OnEnable()
    {
        selectedEvent = eventContainer.GetRandomEvent();
        SetUI(selectedEvent);
    }


    public void SetUI(Event e)
    {
        title.text = e.title;
        description.text = e.description;
        artImage = e.art;
        choice1.SetUI(e.choice1);
        choice2.SetUI(e.choice2);

    }

    
}
