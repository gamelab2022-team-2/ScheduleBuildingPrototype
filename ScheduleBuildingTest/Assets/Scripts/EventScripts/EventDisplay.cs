using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EventDisplay : MonoBehaviour
{

    public Event storyEvent;

    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public Image artImage;

    // When event canvas is setActive set all values to the correct selected event
    public void Start()
    {

        title.text = storyEvent.title;
        description.text = storyEvent.description;
        artImage = storyEvent.art;
        
    }

    
}
