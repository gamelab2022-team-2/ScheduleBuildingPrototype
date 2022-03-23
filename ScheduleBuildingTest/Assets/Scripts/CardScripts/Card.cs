using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
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

    // status card info
    public bool isConnection;
    public bool isAnxiety;


    public bool inHand;
    public bool inSchedule;

    void Start()
    {

        Debug.Log("start");
        if (cardData != null)
        {
            Debug.Log("data loading called");
            LoadData(cardData);
        }
    }

    public void Update()
    {
        if (inHand)
        {
            PlaceInSchedule();
        }
    }

    public void LoadData(CardData data)
    {
        description = data.description;
        grades = data.grades;
        motivation = data.motivation;

        inHandMotiv = data.inHandMotiv;
        anxiety = data.anxiety;

        isStatus = data.isStatus;
        isConnection = data.isConnection;
        isAnxiety = data.isAnxiety;
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
