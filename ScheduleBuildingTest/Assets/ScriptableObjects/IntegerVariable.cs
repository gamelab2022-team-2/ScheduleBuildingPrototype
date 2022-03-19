using System;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu]
    public class IntegerVariable : ScriptableObject, ISerializationCallbackReceiver
    {
        public int initialValue;

        [NonSerialized]
        public int runtimeValue;

        public void OnAfterDeserialize()
        {
            runtimeValue = initialValue;
        }

        public void OnBeforeSerialize() { }
    }
}