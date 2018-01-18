using UnityEngine;
using UnityEditor;



namespace SOA
{
    [CustomEditor(typeof(Vector3EventAsset))]
    public class Vector3EventAssetEditor : EventAssetEditor<Vector3>
    { }
}