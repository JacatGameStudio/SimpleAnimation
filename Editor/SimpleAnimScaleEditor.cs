using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimScale))]
    [CanEditMultipleObjects]
    public class SimpleAnimScaleEditor : SimpleAnimBaseEditor
    {
        SerializedProperty scaleStart;
        SerializedProperty scaleEnd;

        protected override void Awake()
        {
            base.Awake();

            scaleStart = serializedObject.FindProperty("scaleStart");
            scaleEnd = serializedObject.FindProperty("scaleEnd");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(15);

            EditorGUILayout.PropertyField(scaleStart, GUILayout.MaxWidth(450));
            EditorGUILayout.PropertyField(scaleEnd, GUILayout.MaxWidth(450));

            serializedObject.ApplyModifiedProperties();
        }
    }
}
