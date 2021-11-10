using DG.Tweening;
using UnityEngine;
using MyBox;
using System;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimBase : MonoBehaviour
    {
        [SerializeField] protected Ease showEase, hideEase;

        [SerializeField] protected bool useDefaultSetting = true;

        [ConditionalField(nameof(useDefaultSetting), true)] [Tooltip("Time duration of animation")] [SerializeField] protected float timeDuration = 0.385f;
        [ConditionalField(nameof(useDefaultSetting), true)] [Tooltip("Time delay before start amimation")] [SerializeField] protected float timeDelay = 0;
        [ConditionalField(nameof(useDefaultSetting), true)] [Tooltip("Time delay before start amimation")] [SerializeField] protected TimeTriggerAnim triggerAnim = TimeTriggerAnim.NotSet;
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] protected bool hideOnAwake = true;

        /// <summary>
        /// Time duration of animation
        /// </summary>
        public float TimeDuration { get => timeDuration; }

        /// <summary>
        /// Time delay before start amimation
        /// </summary>
        public float TimeDelay { get => timeDelay; }

        public virtual void Show() { }
        public virtual void Hide() { }
    }

    
    public enum TimeTriggerAnim
    {
        NotSet = 0, OnEnable = 1, OnStart = 2
    }
}
