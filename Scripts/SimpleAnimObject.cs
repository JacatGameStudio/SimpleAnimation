using System;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimObject : MonoBehaviour
    {
        SimpleAnimBase[] simpleAnim;
        bool checkInit = false;
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
            set
            {
                foreach(var i in simpleAnim)
                {
                    i.TimeDuration = value;
                }
            }
        }

        private void Awake()
        {
            simpleAnim = GetComponents<SimpleAnimBase>();
            checkInit = true;
        }

        public void Show(bool immediately = false)
        {
            if (!checkInit)
                return;
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Show(immediately);
            }
        }

        public void Show(Action onEndShow, bool immediately = false)
        {
            if (!checkInit)
                return;
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Show(onEndShow, immediately);
            }
        }

        public void Hide(bool immediately = false)
        {
            if (!checkInit)
                return;
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Hide(immediately);
            }
        }

        public void Hide(Action onEndHide, bool immediately = false)
        {
            if (!checkInit)
                return;
            foreach (var i in simpleAnim)
            {
                if (i.isActiveAndEnabled)
                    i.Hide(onEndHide, immediately);
            }
        }

        public SimpleAnimBase GetAnimBase()
        {
            if (!checkInit)
                return null;
            if (simpleAnim.Length == 0)
            {
                Debug.LogError("This SimpleAnimObject does not have any SimpleAnimBase component");
                return null;
            }
            return simpleAnim[0];
        }
    }
}
