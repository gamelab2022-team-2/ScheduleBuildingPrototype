using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/event")]
public class Event : ScriptableObject
{
    // this class contains 2 choice for the event, the event description text and the event art

    public int eventID;
    public string title;

    public int eventKarma;
    public int eventPriority;

    [TextArea]
    public string description;

    public Image art;

    public EventChoice choice1;
    public EventChoice choice2;

    public bool hasPrerequisite;
    public Event eventUnlock;
    

}
