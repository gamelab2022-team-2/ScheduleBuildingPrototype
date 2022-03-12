using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event database", menuName = "Databases/Event Database" )]
public class EventDatabase : ScriptableObject
{

    // This object holds all the events 

    public List<Event> availableEvents;

    public List<Event> usedEvents;

    public List<Event> eventsWithPrecondition;


    // methode to reinitialize the event database 
    public void ReinitializeEventDB()
    {

        availableEvents.AddRange(usedEvents.Where(e => !e.hasPrerequisite));
        eventsWithPrecondition.AddRange(usedEvents.Where(e => e.hasPrerequisite));

        usedEvents.Clear();
    }

}
