using UnityEngine;
using UnityEditor;



namespace SOA
{
    [CustomEditor(typeof(FloatEventAsset))]
    public class FloatEventAssetEditor : EventAssetEditor<float>
    { }
}