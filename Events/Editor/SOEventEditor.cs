using UnityEngine;
using UnityEditor;



namespace SOA
{
    [CustomEditor(typeof(SOEvent))]
    public class SOEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying && GUILayout.Button("Invoke")) (target as SOEvent).Invoke();
        }
    }



    public abstract class SOEventEditor<T> : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (Application.isPlaying && GUILayout.Button("Invoke"))
            {
                var t = target as SOEvent<T>;
                t.Invoke(t.TestValue);
            }
        }
    }
}