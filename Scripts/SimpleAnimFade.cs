using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;
using System;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(SimpleAnimObject))]

    public class SimpleAnimFade : SimpleAnimBase
    {
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float opacityStart = 0;
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float opacityEnd = 1;

        CanvasGroup canvasGroup;
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
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

        public override void Show(bool immediately = false)
        {
            if (hideOnAwake)
                canvasGroup.alpha = 0;

            if (!immediately)
                canvasGroup.DOFade(opacityEnd, timeDuration > 0 ? timeDuration : 0.1f).From(opacityStart).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
            else
                canvasGroup.alpha = opacityEnd;
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (hideOnAwake)
                canvasGroup.alpha = 0;

            if (!immediately)
                canvasGroup.DOFade(opacityEnd, timeDuration > 0 ? timeDuration : 0.1f).From(opacityStart).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
            else
                canvasGroup.alpha = opacityEnd;
        }

        public override void Hide(bool immediately = false)
        {
            if (!immediately)
                canvasGroup.DOFade(opacityStart, timeDuration > 0 ? timeDuration : 0.1f).From(opacityEnd).SetEase(hideEase);
            else
                canvasGroup.alpha = opacityEnd;
        }

        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if(!immediately)
                canvasGroup.DOFade(opacityStart, timeDuration > 0 ? timeDuration : 0.1f).From(opacityEnd).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
            else
            {
                canvasGroup.alpha = opacityStart;
                onEndHide?.Invoke();
            }
        }
    }
}
