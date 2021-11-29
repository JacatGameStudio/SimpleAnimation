using DG.Tweening;
using System;
using UnityEngine;
namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimSlide : SimpleAnimBase
    {
        [SerializeField] Vector2 posStart;
        [SerializeField] Vector2 posEnd;

        RectTransform rect;

        public Vector2 PosStart { get => posStart; set => posStart = value; }
        public Vector2 PosEnd { get => posEnd; set => posEnd = value; }
        public RectTransform Rect { get => rect; set => rect = value; }

        private void Awake()
        {
            rect = GetComponent<RectTransform>();
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
                rect.anchoredPosition = posStart;
                rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
            }
            else
            {
                rect.anchoredPosition = posEnd;
            }
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (!immediately)
            {
                rect.anchoredPosition = posStart;
                rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
            }
            else
            {
                if (!advancedSetting)
                {
                    rect.anchoredPosition = posEnd;
                    onEndStart?.Invoke();
                }
            }
        }
        public override void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
            }
            else
            {
                rect.anchoredPosition = posStart;
            }
        }


        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if (!immediately)
            {
                rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
            }
            else
            {
                rect.anchoredPosition = posStart;
                onEndHide?.Invoke();
            }
        }
    }

    enum Direction
    {
        NotSet = 0, Top = 1, Bottom = 2, Left = 3, Right = 4
    }
}
