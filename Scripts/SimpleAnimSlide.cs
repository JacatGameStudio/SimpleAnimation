using DG.Tweening;
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

        private void Awake()
        {
            bool isRect = TryGetComponent<RectTransform>(out RectTransform _rect);
            if (isRect)
            {
                rect = _rect;
            }
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
            if (!immediately)
            {
                if (rect != null)
                {
                    rect.anchoredPosition = posStart;
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
                }
                else
                {
                    transform.position = posStart;
                    transform.DOMove(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
                }
            }
            else
            {
                if(rect != null)
                    rect.anchoredPosition = posEnd;
                else
                {
                    transform.position = posEnd;
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
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
                }
                else
                {
                    transform.position = posStart;
                    transform.DOMove(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
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
                    transform.position = posEnd;
                    onEndStart?.Invoke();
                }
            }
        }
        public override void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                if(rect != null)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                else
                {
                    transform.DOMove(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                }
            }
            else
            {
                if(rect != null)
                    rect.anchoredPosition = posStart;
                else
                {
                    transform.position = posStart;
                }
            }
        }


        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if (!immediately)
            {
                if(rect != null)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
                else
                    transform.DOMove(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
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
                    transform.position = posStart;
                    onEndHide?.Invoke();
                }
            }
        }
    }
}
