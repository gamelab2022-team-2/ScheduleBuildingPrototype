using ScriptableObjects;
using TMPro;
using UnityEngine;

public class IntegerVariableTMP : MonoBehaviour
{
    public IntegerVariable integerVariable;
    public TextMeshProUGUI textMesh;
    private float value;

    public void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        value = integerVariable.initialValue;
    }

    public void Update()
    {
        SmoothTextChange();
    }

    public void UpdateText()
    {
        //textMesh.text = integerVariable.runtimeValue.ToString();
    }

    public void SmoothTextChange()
    {
        value = Mathf.Lerp(value, integerVariable.runtimeValue, 0.1f);
        var displayvalue = Mathf.RoundToInt(value);
        textMesh.text = displayvalue.ToString();
    }
}