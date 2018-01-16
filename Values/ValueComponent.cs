using UnityEngine;



namespace SOA
{
    public abstract class ValueComponent<T> : MonoBehaviour
    {
        public T Value;
    }
}