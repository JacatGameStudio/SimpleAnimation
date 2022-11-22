
using UnityEditor;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimSlideRelative))]
    [CanEditMultipleObjects]
    public class SimpleAnimSlideRelativeEditor : SimpleAnimBaseEditor
    {
        SerializedProperty posStart;
        //SerializedProperty posEnd;
        SerializedProperty addition;

        SimpleAnimSlideRelative m_Target;

        protected override void Awake()
        {
            base.Awake();

            posStart = serializedObject.FindProperty("posStart");
            addition = serializedObject.FindProperty("posEnd");

            m_Target = target as SimpleAnimSlideRelative;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(15);

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posStart, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Start Pos", GUILayout.MaxWidth(80)))
            {
                if (m_Target.rect != null)
                    m_Target.PosStart = m_Target.rect.anchoredPosition;
                else
                    m_Target.PosStart = m_Target.transform.localPosition;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(addition, new GUIContent("Addition"), GUILayout.MaxWidth(450));
            if (GUILayout.Button("Addition", GUILayout.MaxWidth(80)))
            {
                if (m_Target.rect != null)
                    m_Target.PosEnd = m_Target.rect.anchoredPosition - m_Target.PosStart;
                else
                    m_Target.PosEnd = (Vector2)m_Target.transform.localPosition - m_Target.PosStart;
            }
            GUILayout.EndHorizontal();
            serializedObject.ApplyModifiedProperties();
        }
    }
}