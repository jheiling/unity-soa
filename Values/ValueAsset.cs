using UnityEngine;



namespace SOA
{
    public abstract class ValueAsset<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif
        public bool IsPersistent;

        [SerializeField]
        T _value;

        T _currentValue;

        public T Value
        {
            get
            {
                return IsPersistent ? _value : _currentValue;
            }

            set
            {
                if (IsPersistent) _value = value;
                else _currentValue = value;
            }
        }

        void OnEnable()
        {
            if (!IsPersistent) _currentValue = _value;
        }
    }
}