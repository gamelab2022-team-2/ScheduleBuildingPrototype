using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event database", menuName = "Databases/Event Database" )]
public class EventDatabase : ScriptableObject
{

    // This object holds all the events 

    public List<Event> availableEvents;

    public List<Event> usedEvents;

    public List<Event> eventsWithPrecondition;
 
}
