using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public string initialValue;

        [NonSerialized]
        public string runtimeValue;

        public void OnAfterDeserialize()
        {
            runtimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}