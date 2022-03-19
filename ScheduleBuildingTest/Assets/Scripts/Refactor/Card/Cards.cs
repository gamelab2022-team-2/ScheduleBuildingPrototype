using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card ", menuName = "Card")]

public class Cards : ScriptableObject
{

    // played variables
    //public GameObject tetronimo; TO BE ADDED maybe as GameObject??
    [TextArea]
    public string description;
    public int grades;
    public int motivation;


    // inhand (not played) variables
    public int inHandMotiv;
    public int anxiety;

    // card state variables
    public bool isStatus;
    public bool inSchedule;

    // status card info
    public bool isConnection;
    public bool isAnxiety;

    public bool inHand;


}
