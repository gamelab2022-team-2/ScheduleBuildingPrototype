using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventCanvas : MonoBehaviour
{
    public GameObject chosenEvent;

    public static EventCanvas instance;


    public void Awake()
    {
        
        //chosenEvent = EventStorage.instance.PickRandomEvent();
        //chosenEvent.SetActive(true);
    }
}
