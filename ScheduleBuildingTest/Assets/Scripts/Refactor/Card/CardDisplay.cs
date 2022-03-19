using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{
    // this class just fills the event canvas with the values of a selected event

    public TextMeshProUGUI description;

    public TextMeshProUGUI motiv;
    public TextMeshProUGUI grade;

    public TextMeshProUGUI inHandMotiv;
    public TextMeshProUGUI anx;



    public void SetUI(CardData c)
    {
        description.text = c.description;

        motiv.text = c.motivation.ToString();
        grade.text = c.grades.ToString();

        inHandMotiv.text = c.inHandMotiv.ToString();
        anx.text = c.anxiety.ToString();


    }
}
