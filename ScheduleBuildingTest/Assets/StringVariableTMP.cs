using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class StringVariableTMP : MonoBehaviour
{
    public StringVariable stringVariable;
    public TextMeshProUGUI textMesh;
    
    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        textMesh.text = stringVariable.runtimeValue;
    }
}
