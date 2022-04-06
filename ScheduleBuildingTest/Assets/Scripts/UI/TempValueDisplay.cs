using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class TempValueDisplay : MonoBehaviour
{
    public TextMeshProUGUI grades, motivation;
    public int gradeValue, motivationValue;
    public Player player;

    public void Awake()
    {
        ApplyHand();
    }

    public void ApplyHand()
    {
        motivationValue = player.Motivation;
        gradeValue = player.Grade;

        Debug.Log("Apply hand started. Motivation value = " + motivationValue.ToString());
        for (int c = 0; c < player.hand.Count; c++)
        {
            if (c < player.gridObjects.Count)
            {
                Card resolvingCard = player.hand.GetAtIndex(c);
                if (player.gridObjects[c].OnGrid())
                {

                    for (int m = 0; m < resolvingCard.placedResolve.Count; m++)
                    {
                        if (resolvingCard.placedResolve[m].Equals("ChangeMotivation") || resolvingCard.placedResolve[m].Equals("ChangeGrades"))
                        {
                            Type thisType = this.GetType();
                            MethodInfo theMethod = thisType
                                .GetMethod(resolvingCard.placedResolve[m]);
                            theMethod.Invoke(this, new object[] { resolvingCard.placedResolveParams[m] });
                        }

                    }
                }
                else
                {

                    for (int m = 0; m < resolvingCard.unplacedResolve.Count; m++)
                    {
                        if (resolvingCard.unplacedResolve[m].Equals("ChangeMotivation") || resolvingCard.unplacedResolve[m].Equals("ChangeGrades"))
                        {
                            Type thisType = this.GetType();
                            MethodInfo theMethod = thisType
                                .GetMethod(resolvingCard.unplacedResolve[m]);
                            theMethod.Invoke(this, new object[] { resolvingCard.unplacedResolveParams[m] });
                        }

                    }
                }
            }

            UpdateDisplay();
        }
    }

    public void ChangeMotivation(int i)
    {
       
        motivationValue += i + player.motivationModifier;
    }

    public void ChangeGrades(int i)
    {
        gradeValue += i + player.gradeModifier;
    }

    public void UpdateDisplay()
    {
        grades.text = "(" + gradeValue.ToString() + ")";
        motivation.text = "(" + motivationValue.ToString() + ")";
    }

}
