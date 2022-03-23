using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public CardData cardData;
    // played variables

    public string shape;
    public Color shapeColor;

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
        shapeColor = data.shapeColor;
        shape = data.shape;
    }

 

}
