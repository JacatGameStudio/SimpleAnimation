using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;
using System;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimScale : SimpleAnimBase
    {
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float scaleStart = 0;
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float scaleEnd = 1;

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

        public override void Show(bool immediately = false)
        {
            if (hideOnAwake)
                transform.localScale = Vector3.zero;

            if (!immediately)
                transform.DOScale(scaleEnd, timeDuration > 0 ? timeDuration : 0.1f).From(scaleStart).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
            else
                transform.localScale = scaleEnd * Vector3.one;
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (hideOnAwake)
                transform.localScale = Vector3.zero;

            if (!immediately)
                transform.DOScale(scaleEnd, timeDuration > 0 ? timeDuration : 0.1f).From(scaleStart).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
            else
            {
                onEndStart?.Invoke();
                transform.localScale = scaleEnd * Vector3.one;
            }
        }

        public override void Hide(bool immediately = false)
        {
            if (!immediately)
                transform.DOScale(scaleStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
            else
                transform.localScale = scaleStart * Vector3.one;
        }

        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if(!immediately)
                transform.DOScale(scaleStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
            else
            {
                transform.localScale = scaleStart * Vector3.one;
                onEndHide?.Invoke();
            }
        }
    }
}
