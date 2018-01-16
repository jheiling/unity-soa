using UnityEngine;



namespace SOA
{
    public abstract class ValueAsset<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif
        public T Value;
    }
}