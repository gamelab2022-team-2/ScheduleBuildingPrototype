using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class FloatVariableTMP : MonoBehaviour
{
    public FloatVariable floatVariable;
    public TextMeshProUGUI textMesh;
    
    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText()
    {
        textMesh.text = floatVariable.runtimeValue.ToString();
    }
}
