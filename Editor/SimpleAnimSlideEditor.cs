using UnityEditor;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [CustomEditor(typeof(SimpleAnimSlide))]
    [CanEditMultipleObjects]
    public class SimpleAnimSlideEditor : SimpleAnimBaseEditor
    {
        SerializedProperty posStart;
        SerializedProperty posEnd;

        RectTransform rect;
        SimpleAnimSlide slideAnim;

        protected override void Awake()
        {
            base.Awake();

            posStart = serializedObject.FindProperty("posStart");
            posEnd = serializedObject.FindProperty("posEnd");

            slideAnim = target as SimpleAnimSlide;
            bool isRect = slideAnim.TryGetComponent<RectTransform>(out RectTransform _rect);
            if (isRect)
            {
                rect = _rect;
            }
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            GUILayout.Space(15);

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posStart, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                if (rect != null)
                    slideAnim.PosStart = rect.anchoredPosition;
                else
                    slideAnim.PosStart = slideAnim.transform.localPosition;
            }
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            EditorGUILayout.PropertyField(posEnd, GUILayout.MaxWidth(450));
            if (GUILayout.Button("Get Pos", GUILayout.MaxWidth(80)))
            {
                if (rect != null)
                    slideAnim.PosEnd = rect.anchoredPosition;
                else
                    slideAnim.PosEnd = slideAnim.transform.localPosition;
            }
            GUILayout.EndHorizontal();

            serializedObject.ApplyModifiedProperties();
            EditorUtility.SetDirty(slideAnim);
        }
    }
}
