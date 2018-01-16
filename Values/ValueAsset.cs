using UnityEngine;



namespace SOA
{
    public abstract class ValueAsset<T> : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string Description = "";
#endif
        public bool SetPersistent;

        [SerializeField]
        T _persistantValue;

        T _value;

        public T Value
        {
            get
            {
                return _value;
            }

            set
            {
                _value = value;
                if (SetPersistent) _persistantValue = value;
            }
        }

        void OnEnable()
        {
            _value = _persistantValue;
        }
    }
}