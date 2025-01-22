using UnityEditor;
using UnityEngine;

namespace ObjectToggler.Editor
{
    [CustomPropertyDrawer(typeof(ObjectToggler.Case))]
    public class CasesFieldDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            float lineHeight = EditorGUIUtility.singleLineHeight;
            float verticalSpacing = 2;

            SerializedProperty caseNameProp = property.FindPropertyRelative("_caseName");
            position.height = lineHeight;
            EditorGUI.PropertyField(position, caseNameProp);
            position.y += lineHeight + verticalSpacing;

            SerializedProperty caseObjectProp = property.FindPropertyRelative("_caseObject");
            position.height = lineHeight;
            EditorGUI.PropertyField(position, caseObjectProp);
            position.y += lineHeight + verticalSpacing;

            SerializedProperty enableOnInitProp = property.serializedObject.FindProperty("_enableOnInit");
            bool shouldHide = enableOnInitProp == null || string.IsNullOrEmpty(enableOnInitProp.stringValue);

            if (!shouldHide)
            {
                SerializedProperty transitionProp = property.FindPropertyRelative("_transition");
                position.height = lineHeight;
                EditorGUI.PropertyField(position, transitionProp);
                position.y += lineHeight + verticalSpacing;

                SerializedProperty backTransitionProp = property.FindPropertyRelative("_backTransition");
                position.height = lineHeight;
                EditorGUI.PropertyField(position, backTransitionProp);
            }

            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            float lineHeight = EditorGUIUtility.singleLineHeight;
            float verticalSpacing = 2;
            float height = lineHeight + verticalSpacing;

            SerializedProperty enableOnInitProp = property.serializedObject.FindProperty("_enableOnInit");
            bool shouldHide = enableOnInitProp == null || string.IsNullOrEmpty(enableOnInitProp.stringValue);

            height += lineHeight + verticalSpacing;

            if (!shouldHide)
            {
                height += (lineHeight + verticalSpacing) * 2;
            }

            return height;
        }
    }
}