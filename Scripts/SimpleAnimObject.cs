using System;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimObject : MonoBehaviour
    {
        SimpleAnimBase[] simpleAnim;
        float timeDuration;

        /// <summary>
        /// return timeDuration of first simpleAnimBase
        /// </summary>
        public float TimeDuration
        {
            get
            {
                if (simpleAnim.Length == 0)
                {
                    Debug.LogError("SimpleObject has no SimpleAnimBase");
                    return 0;
                }
                else
                {
                    return simpleAnim[0].TimeDuration;
                }
            }
        }

        private void Awake()
        {
            simpleAnim = GetComponents<SimpleAnimBase>();
        }

        public void Show()
        {
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Show();
            }
        }

        public void Hide()
        {
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Hide();
            }
        }

        public void Hide(Action onEndHide)
        {
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Hide(onEndHide);
            }
        }

        public SimpleAnimBase GetAnimBase()
        {
            if (simpleAnim.Length == 0)
            {
                Debug.LogError("This SimpleAnimObject does not have any SimpleAnimBase component");
                return null;
            }
            return simpleAnim[0];
        }
    }
}
