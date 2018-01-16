using UnityEngine;



namespace SOA
{
   public abstract class ValueRegisterer<T, AT> : MonoBehaviour where T : Component where AT : ValueAsset<T>
    {
        public AT Asset;

        void OnEnable()
        {
            if (Asset) Asset.Value = GetComponent<T>();
        }

        void OnDisable()
        {
            if (Asset) Asset.Value = null;
        }
    }
}