using UnityEditor;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimFade))]
    public class SimpleAnimFadeEditor : SimpleAnimBaseEditor
    {
        SerializedProperty opacityStart;
        SerializedProperty opacityEnd;

        protected override void Awake()
        {
            base.Awake();

            opacityStart = serializedObject.FindProperty("opacityStart");
            opacityEnd = serializedObject.FindProperty("opacityEnd");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(15);

            EditorGUILayout.PropertyField(opacityStart, GUILayout.MaxWidth(450));
            EditorGUILayout.PropertyField(opacityEnd, GUILayout.MaxWidth(450));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
