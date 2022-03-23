using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GameStateMachine))]
public class GameStateMachineEditor : Editor
{
    GameStateMachine gsm;

    void OnEnable() {
        gsm = (GameStateMachine) target;
    }

    public override void OnInspectorGUI()
    {
        
        base.OnInspectorGUI();
        
        if(GUILayout.Button("Next State"))
        {
            //add everthing the button would do.
            Debug.Log("Changing to next state");
            if (gsm != null)
            {
                gsm.NextState();
            }
            else
            {
                Debug.Log("Please enter Play Mode");
            }
        
        }
    }
}
