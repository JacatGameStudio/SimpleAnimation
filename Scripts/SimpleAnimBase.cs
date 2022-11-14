using DG.Tweening;
using UnityEngine;
using System;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimBase : MonoBehaviour
    {
        [SerializeField] protected Ease showEase, hideEase;

        [SerializeField] protected bool advancedSetting = true;

        [Tooltip("Time duration of animation")] [SerializeField] protected float timeDuration = 0.385f;
        [Tooltip("Time delay before start amimation")] [SerializeField] protected float timeDelay = 0;
        [Tooltip("Time trigger amimation")] [SerializeField] protected TimeTriggerAnim triggerAnim = TimeTriggerAnim.OnStart;
        [SerializeField] protected bool hideOnAwake = true;

        [Tooltip("If true, animation will ignore time scale.")]
        [SerializeField] protected bool ignoreTimeScale = false;

        /// <summary>
        /// Time duration of animation
        /// </summary>
        public float TimeDuration { get => timeDuration; set => timeDuration = value; }

        /// <summary>
        /// Time delay before start amimation
        /// </summary>
        public float TimeDelay { get => timeDelay; set => timeDelay = value;}

        public virtual void Show(bool immediately = false) { }
        public virtual void Show(Action onEndStart, bool immediately = false) { }
        public virtual void Hide(bool immediately = false) { }
        public virtual void Hide(Action onEndHide, bool immediately = false) { }

        protected virtual void Awake()
        {
            if (hideOnAwake)
                Hide(true);
        }

        private void OnEnable()
        {
            if (triggerAnim == TimeTriggerAnim.OnEnable)
            {
                Show();
            }
        }

        private void Start()
        {
            if (triggerAnim == TimeTriggerAnim.OnStart)
            {
                Show();
            }
        }
    }

    
    public enum TimeTriggerAnim
    {
        NotSet = 0, OnEnable = 1, OnStart = 2
    }
}
