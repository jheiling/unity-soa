using UnityEngine;
using UnityEditor;



namespace SOA
{
    [CustomEditor(typeof(EventAsset))]
    public class EventAssetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying && GUILayout.Button("Invoke")) (target as EventAsset).Invoke();
        }
    }



    public abstract class EventAssetEditor<T> : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying && GUILayout.Button("Invoke"))
            {
                var t = target as EventAsset<T>;
                t.Invoke(t.TestValue);
            }
        }
    }
}