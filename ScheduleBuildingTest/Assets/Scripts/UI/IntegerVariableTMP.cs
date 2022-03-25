using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class IntegerVariableTMP : MonoBehaviour
{
    public IntegerVariable integerVariable;
    public TextMeshProUGUI textMesh;
    
    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        textMesh.text = integerVariable.runtimeValue.ToString();
    }
}