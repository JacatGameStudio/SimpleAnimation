﻿using DG.Tweening;
using System;
using UnityEngine;
namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimSlide : SimpleAnimBase
    {
        [SerializeField] Vector2 posStart;
        [SerializeField] Vector2 posEnd;

        RectTransform rect;

        public Vector2 PosStart { get => posStart; set => posStart = value; }
        public Vector2 PosEnd { get => posEnd; set => posEnd = value; }

        protected override void Awake()
        {

            bool isRect = TryGetComponent<RectTransform>(out RectTransform _rect);
            if (isRect)
            {
                rect = _rect;
            }
            base.Awake();
        }

        public override void Show(bool immediately = false)
        {
            if (!immediately)
            {
                if (rect != null)
                {
                    rect.anchoredPosition = posStart;
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).SetUpdate(ignoreTimeScale);
                }
                else
                {
                    transform.localPosition = posStart;
                    transform.DOLocalMove(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).SetUpdate(ignoreTimeScale);
                }
            }
            else
            {
                if(rect != null)
                    rect.anchoredPosition = posEnd;
                else
                {
                    transform.localPosition = posEnd;
                }
            }
        }


        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (!immediately)
            {
                if (rect != null)
                {
                    rect.anchoredPosition = posStart;
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
                else
                {
                    transform.localPosition = posStart;
                    transform.DOLocalMove(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
            }
            else
            {
                if (rect != null)
                {
                    rect.anchoredPosition = posEnd;
                    onEndStart?.Invoke();
                }
                else
                {
                    transform.localPosition = posEnd;
                    onEndStart?.Invoke();
                }
            }
        }
        public override void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                if(rect != null)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).SetUpdate(ignoreTimeScale);
                else
                {
                    transform.DOLocalMove(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).SetUpdate(ignoreTimeScale);
                }
            }
            else
            {
                if(rect != null)
                    rect.anchoredPosition = posStart;
                else
                {
                    transform.localPosition = posStart;
                }
            }
        }


        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if (!immediately)
            {
                if(rect != null)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
                else
                    transform.DOLocalMove(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
            }
            else
            {
                if (rect != null)
                {
                    rect.anchoredPosition = posStart;
                    onEndHide?.Invoke();
                }
                else
                {
                    transform.localPosition = posStart;
                    onEndHide?.Invoke();
                }
            }
        }
    }
}
