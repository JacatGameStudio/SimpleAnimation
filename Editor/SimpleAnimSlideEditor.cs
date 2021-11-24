using UnityEditor;
using DG.Tweening;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimSlide))]
    public class SimpleAnimSlideEditor : Editor
    {
        SerializedProperty showEase;
        SerializedProperty hideEase;
        SerializedProperty timeDuration;
        SerializedProperty timeDelay;
        SerializedProperty triggerAnim;
        SerializedProperty hideOnAwake;

        SerializedProperty posStart;
        SerializedProperty posEnd;

        bool advanced;
        RectTransform rect;
        SimpleAnimSlide slideAnim;

        private void Awake()
        {
            showEase = serializedObject.FindProperty("showEase");
            hideEase = serializedObject.FindProperty("hideEase");
            timeDelay = serializedObject.FindProperty("timeDelay");
            triggerAnim = serializedObject.FindProperty("triggerAnim");
            hideOnAwake = serializedObject.FindProperty("hideOnAwake");
            timeDuration = serializedObject.FindProperty("timeDuration");

            posStart = serializedObject.FindProperty("posStart");
            posEnd = serializedObject.FindProperty("posEnd");

            slideAnim = target as SimpleAnimSlide;
            rect = slideAnim.GetComponent<RectTransform>();
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
            }

            GUILayout.Space(15);

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posStart, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                slideAnim.PosStart = rect.anchoredPosition;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posEnd, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                slideAnim.PosEnd = rect.anchoredPosition;
            }
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
}
