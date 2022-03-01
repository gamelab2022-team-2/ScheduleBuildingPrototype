using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    public string Name;

    // Effects on motivation
    public int motivation1;
    public int motivation2;

    // Effects on Grade cards
    public int grade1;
    public int grade2;

    // Blocking section of Grid
    // Shape?

    // cards to be added to discard
    public Card card1;
    public Card card2;

    // Anxiety added
    public int addAnx1;
    public int addAnx2;

    // Anxiety removed
    public int remAnx1;
    public int remAnx2;

    // Connection card added
    public int connect1;
    public int connect2;



    public Event(string nam, int motiv1, int motiv2, int grad1, int grad2, Card car1, Card car2, int aAnx1, int aAnx2, int rAnx1, int rAnx2, int con1, int con2)
    {
        name = nam;

        motivation1 = motiv1;
        motivation2 = motiv2;

        grade1 = grad1;
        grade2 = grad2;

        card1 = car1;
        card2 = car2;

        addAnx1 = aAnx1;
        addAnx2 = aAnx2;

        remAnx1 = rAnx1;
        remAnx2 = rAnx2;

        connect1 = con1;
        connect2 = con2;
    }

    public Event(string nam, int motiv1, int motiv2, int aAnx1, int aAnx2)
    {
        name = nam;
        motivation1 = motiv1;
        motivation2 = motiv2;

        addAnx1 = aAnx1;
        addAnx2 = aAnx2;
    }
    

    public void Apply(int choice)
    {


    }
}
