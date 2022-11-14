using DG.Tweening;
using System;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimSlideRelative : SimpleAnimBase
    {
        [SerializeField] Vector2 posStart;
        [SerializeField] Vector2 posEnd;

        public RectTransform rect;

        public Vector2 PosStart { get => posStart; set => posStart = value; }
        public Vector2 PosEnd { get => posEnd; set => posEnd = value; }

        enum MoveType
        {
            LocalPosition = 0, //move object to the designated local position
            Relative = 1 //move object by adding in value to position
        }
        MoveType moveType = MoveType.Relative;

        protected override void Awake()
        {
            TryGetComponent<RectTransform>(out rect);
            base.Awake();
        }

        public override void Show(bool immediately = false)
        {
            Show(null, immediately);
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (!immediately)
            {
                if (rect != null)
                {
                    rect.anchoredPosition = GetFinalPosition(rect.anchoredPosition, posStart);
                    rect.DOAnchorPos(GetFinalPosition(rect.anchoredPosition, posEnd), timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
                else
                {
                    transform.localPosition = GetFinalPosition(transform.localPosition, posStart);
                    transform.DOLocalMove(GetFinalPosition(transform.localPosition, posEnd), timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
            }
            else
            {
                if (rect != null)
                {
                    rect.anchoredPosition = GetFinalPosition(rect.anchoredPosition, posEnd);
                    onEndStart?.Invoke();
                }
                else
                {
                    transform.localPosition = GetFinalPosition(transform.localPosition, posEnd);
                    onEndStart?.Invoke();
                }
            }
        }

        Vector3 GetFinalPosition(Vector3 currentLocalPos, Vector3 additionalPos)
        {
            switch (moveType)
            {
                case MoveType.LocalPosition:
                    return additionalPos;
                case MoveType.Relative:
                    return currentLocalPos + additionalPos;
            }
            return additionalPos;
        }

        public override void Hide(bool immediately = false)
        {
            Hide(null, immediately);
        }


        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if (!immediately)
            {
                if (rect != null)
                    rect.DOAnchorPos(GetFinalPosition(rect.anchoredPosition, posStart), timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
                else
                    transform.DOLocalMove(GetFinalPosition(transform.localPosition, posStart), timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
            }
            else
            {
                if (rect != null)
                {
                    rect.anchoredPosition = GetFinalPosition(rect.anchoredPosition, posStart);
                    onEndHide?.Invoke();
                }
                else
                {
                    transform.localPosition = GetFinalPosition(transform.localPosition, posStart);
                    onEndHide?.Invoke();
                }
            }
        }
    }
}