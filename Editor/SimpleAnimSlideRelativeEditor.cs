
using UnityEditor;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimSlideRelative))]
    [CanEditMultipleObjects]
    public class SimpleAnimSlideRelativeEditor : SimpleAnimBaseEditor
    {
        SerializedProperty posStart;
        SerializedProperty posEnd;

        SimpleAnimSlideRelative m_Target;

        protected override void Awake()
        {
            base.Awake();

            posStart = serializedObject.FindProperty("posStart");
            posEnd = serializedObject.FindProperty("posEnd");

            m_Target = target as SimpleAnimSlideRelative;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(15);

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posStart, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                if (m_Target.rect != null)
                    m_Target.PosStart = m_Target.rect.anchoredPosition;
                else
                    m_Target.PosStart = m_Target.transform.localPosition;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posEnd, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                if (m_Target.rect != null)
                    m_Target.PosEnd = m_Target.rect.anchoredPosition;
                else
                    m_Target.PosEnd = m_Target.transform.localPosition;
            }
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
}