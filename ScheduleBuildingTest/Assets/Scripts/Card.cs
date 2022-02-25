using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    //public GameObject tetronimo; TO BE ADDED maybe as GameObject??
    public string description;
    public int grades;
    public int motivation;
    public int anxiety;
    public bool isStatus;
    public bool inSchedule;

    [HideInInspector]
    public bool inHand;


    public Card(string descript, int grad, int motiv, int anx)
    {
        description = descript;
        grades = grad;
        motivation = motiv;
        anxiety = anx;
    }
}
