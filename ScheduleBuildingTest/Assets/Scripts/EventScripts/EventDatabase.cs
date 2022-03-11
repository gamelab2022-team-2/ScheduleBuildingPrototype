using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Event database", menuName = "Databases/Event Database" )]
public class EventDatabase : ScriptableObject
{
    public List<Event> eventList;
 
}
