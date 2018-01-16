using UnityEngine;
using UnityEditor;



namespace SOA
{
    [CustomEditor(typeof(Vector3SOEvent))]
    public class Vector3GameEventEditor : SOEventEditor<Vector3>
    { }
}