using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Game;

public class EventDisplay : MonoBehaviour
{

    // this class just fills the event canvas with the values of a selected event
    public Event selectedEvent;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Sprite artImage;

    public EventContainer eventContainer;

    public ChoiceDisplay choice1;
    public ChoiceDisplay choice2;

    public GameObject loadableImage;

    public void SelectEvent()
    {
        Debug.Log("Event Display On enabled called");

        if (GameManager.Instance.turn.runtimeValue == 2)
        {
            selectedEvent = eventContainer.FindEventByIdInAvail(1);
            Debug.Log("Display event selected is " + selectedEvent.eventID);
        }
        else
        {
            selectedEvent = eventContainer.GetRandomEvent();
        }
        
        SetUI(selectedEvent);
    }


    public void SetUI(Event e)
    {
        title.text = e.title;
        description.text = e.description;
        artImage = e.art;
        loadableImage.GetComponentInChildren<Image>().sprite = artImage;
        choice1.SetUI(e.choice1);
        choice2.SetUI(e.choice2);

    }

    
}
