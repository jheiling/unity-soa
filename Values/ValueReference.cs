using UnityEngine;



namespace SOA
{
    public abstract class ValueReference<T, AT> where AT : ValueAsset<T>
    {
        public bool UseAsset;
        [SerializeField] T _value;
        public AT Asset;

        public ValueReference() { }

        public ValueReference(T value)
        {
            _value = value;
        }

        public T Value
        {
            get
            {
                return UseAsset ? Asset.Value : _value;
            }
            set
            {
                if (UseAsset) Asset.Value = value;
                else _value = value;
            }
        }

        public static implicit operator T(ValueReference<T, AT> reference)
        {
            return reference.Value;
        }
    }
}