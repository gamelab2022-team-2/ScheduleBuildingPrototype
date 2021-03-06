using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Event", menuName = "Event/Choice")]
public class EventChoice : ScriptableObject
{
    //// This class contains the information about choices that can be made during an event

    //public string title;
    //[TextArea]
    //public string description;

    //// Effects on motivation
    //public int motivation;

    //// Effects on Grade cards
    //public int grade;

    //// Blocking section of Grid
    //// Shape?

    //// cards to be added to discard
    //public Card card;

    //// Anxiety added
    //public int addAnx;

    //// Anxiety removed
    //public int remAnx1;

    //// Connection card added
    //public int connect;

    //// Future event unlocked
    //public Event unlockedEvent;


    public int eventChoiceId;

    public string title;

    public int karmaValue;

    [TextArea]
    public string description;

    public List<string> choiceResolve;
    public List<int> choiceParams;





}
