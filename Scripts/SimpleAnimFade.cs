using DG.Tweening;
using System;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(SimpleAnimObject))]

    public class SimpleAnimFade : SimpleAnimBase
    {
        [SerializeField] float opacityStart = 0;
        [SerializeField] float opacityEnd = 1;

        CanvasGroup canvasGroup;
        protected override void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
            base.Awake();
        }

        public override void Show(bool immediately = false)
        {
            if (!immediately)
                canvasGroup.DOFade(opacityEnd, timeDuration > 0 ? timeDuration : 0.1f).From(opacityStart).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
            else
                canvasGroup.alpha = opacityEnd;
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
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
            if (!immediately)
                canvasGroup.DOFade(opacityStart, timeDuration > 0 ? timeDuration : 0.1f).From(opacityEnd).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
            else
            {
                canvasGroup.alpha = opacityStart;
                onEndHide?.Invoke();
            }
        }
    }
}
