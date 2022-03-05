using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    // played variables
    //public GameObject tetronimo; TO BE ADDED maybe as GameObject??
    public string description;
    public int grades;
    public int motivation;
    

    // inhand (not played) variables
    public int inHandMotiv;
    public int anxiety;

    // card state variables
    public bool isStatus;
    public bool inSchedule;


    public bool isConnection;
    public bool isAnxiety;

    [HideInInspector]
    public bool inHand;


    public Card(string descript, int grad, int motiv,int inHandMotivation, int anx, bool isAnx, bool isConnect)
    {
        description = descript;
        grades = grad;
        motivation = motiv;
        anxiety = anx;
        inHandMotiv = inHandMotivation;
        isAnxiety = isAnx;
        inSchedule = false;
        inHand = false;

        if (isAnx == true)
        {
            isStatus = true;
            isAnxiety = true;
        }           
        else if (isConnect == true)
        {
            isStatus = true;
            isConnection = true;
        }          
        else
            isStatus = false;

    }

    public void Update()
    {
        if (inHand)
        {
            PlaceInSchedule();
        }
    }

    // Temporary method to replace placing tetronimo in schedule
    public void PlaceInSchedule()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {
                    inSchedule = true;
                }
            }
        }
    }

}
