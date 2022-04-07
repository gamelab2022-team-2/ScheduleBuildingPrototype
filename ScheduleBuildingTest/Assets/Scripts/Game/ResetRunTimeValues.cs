using ScriptableObjects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetRunTimeValues : MonoBehaviour
{
    public IntegerVariable grade, motivation, turn;

    public void ResetVariables()
    {
        grade.runtimeValue = grade.initialValue;
        motivation.runtimeValue = motivation.initialValue;
        turn.runtimeValue = turn.initialValue;

    }

}
