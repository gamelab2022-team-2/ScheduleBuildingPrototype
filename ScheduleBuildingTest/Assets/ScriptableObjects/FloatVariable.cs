using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class FloatVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public float initialValue;

        [NonSerialized]
        public float RuntimeValue;

        public void OnAfterDeserialize()
        {
            RuntimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}