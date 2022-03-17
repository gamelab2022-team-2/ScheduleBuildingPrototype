using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameStateMachine))]
public class GameStateMachineEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Next State"))
        {
        //add everthing the button would do.
        Debug.Log("Hi");
        }
    }
}
