using DG.Tweening;
using UnityEngine;
using MyBox;
using System;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimBase : MonoBehaviour
    {
        public Ease showEase, hideEase;
        public Action onStartShow, onEndShow, onStartHide, onEndHide;

        [SerializeField] protected bool useDefault = true;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] protected TimeFireShowAnim timeFireShowAnim = TimeFireShowAnim.OnStart;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] protected TimeFireHideAnim timeFireHideAnim = TimeFireHideAnim.NotSet;

        [ConditionalField(nameof(useDefault), true)] [SerializeField] protected float timeDuration = 0.385f;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] protected float timeDelay = 0;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] protected bool enableOnAwake = true;

        public virtual void Show() { }
        public virtual void Hide() { }
    }

    
    public enum TimeFireShowAnim
    {
        NotSet = 0, OnEnable = 1, OnStart = 2
    }

    public enum TimeFireHideAnim
    {
        NotSet = 0, OnDisable = 1, OnDestroy = 2
    }
}
