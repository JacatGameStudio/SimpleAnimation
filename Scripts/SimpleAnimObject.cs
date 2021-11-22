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
                    throw new NullReferenceException("SimpleObject has no SimpleAnimBase");
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

        public void Show(bool immediately = false)
        {
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Show(immediately);
            }
        }

        public void Hide(bool immediately = false)
        {
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Hide(immediately);
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
