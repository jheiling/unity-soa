using UnityEngine;
using UnityEditor;



namespace SOA
{
    public abstract class ValueReferenceDrawer : PropertyDrawer
    {
        readonly static string[] popupOptions = { "Use Asset", "Use Local" };
        GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (popupStyle == null)
            {
                popupStyle = new GUIStyle(GUI.skin.GetStyle("PaneOptions"));
                popupStyle.imagePosition = ImagePosition.ImageOnly;
            }

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            var useAsset = property.FindPropertyRelative("UseAsset");
            var value = property.FindPropertyRelative("_value");
            var asset = property.FindPropertyRelative("Asset");

            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            useAsset.boolValue = EditorGUI.Popup(buttonRect, useAsset.boolValue ? 0 : 1, popupOptions, popupStyle) == 0;

            EditorGUI.PropertyField(position, useAsset.boolValue ? asset : value, GUIContent.none);

            if (EditorGUI.EndChangeCheck()) property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }
    }
}