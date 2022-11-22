using UnityEditor;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimBase))]
    public class SimpleAnimBaseEditor : Editor
    {
        protected SerializedProperty showEase;
        protected SerializedProperty hideEase;
        protected SerializedProperty timeDuration;
        protected SerializedProperty timeDelay;
        protected SerializedProperty triggerAnim;
        protected SerializedProperty hideOnAwake;
        protected SerializedProperty ignoreTimeScale;

        bool advanced;
        protected virtual void Awake()
        {
            showEase = serializedObject.FindProperty("showEase");
            hideEase = serializedObject.FindProperty("hideEase");
            timeDelay = serializedObject.FindProperty("timeDelay");
            triggerAnim = serializedObject.FindProperty("triggerAnim");
            hideOnAwake = serializedObject.FindProperty("hideOnAwake");
            timeDuration = serializedObject.FindProperty("timeDuration");
            ignoreTimeScale = serializedObject.FindProperty("ignoreTimeScale");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(showEase);
            EditorGUILayout.PropertyField(hideEase);

            advanced = EditorGUILayout.Foldout(advanced, new GUIContent("Advanced"));
            if (advanced)
            {
                EditorGUILayout.PropertyField(timeDuration);
                EditorGUILayout.PropertyField(timeDelay);
                EditorGUILayout.PropertyField(triggerAnim);
                EditorGUILayout.PropertyField(hideOnAwake);
                EditorGUILayout.PropertyField(ignoreTimeScale);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
}
