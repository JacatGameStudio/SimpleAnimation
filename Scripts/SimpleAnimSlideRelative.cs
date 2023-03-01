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

        public Vector2 PosStart
        {
            get => posStart;
            set => posStart = value;
        }

        public Vector2 PosEnd
        {
            get => posEnd;
            set => posEnd = value;
        }

        enum MoveType
        {
            LocalPosition = 0, //move object to the designated local position
            Relative = 1 //move object by adding in value to position
        }

        MoveType moveType = MoveType.Relative;
        private Vector2 initialPosition;

        protected override void Awake()
        {
            TryGetComponent<RectTransform>(out rect);
            if (rect != null)
            {
                initialPosition = rect.anchoredPosition;
            }
            else
            {
                initialPosition = transform.position;
            }

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
                SetTransformPosition(GetFinalPosition(initialPosition, posStart));
                if (rect != null)
                {
                    rect.DOAnchorPos(GetFinalPosition(initialPosition, posEnd), timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
                else
                {
                    transform.DOLocalMove(GetFinalPosition(initialPosition, posEnd), timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndStart?.Invoke());
                }
            }
            else
            {
                SetTransformPosition(GetFinalPosition(initialPosition, posEnd));
                onEndStart?.Invoke();
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
                SetTransformPosition(GetFinalPosition(initialPosition, posEnd));
                if (rect != null)
                {
                    rect.DOAnchorPos(GetFinalPosition(initialPosition, posStart), timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
                }
                else
                {
                    transform.DOLocalMove(GetFinalPosition(initialPosition, posStart), timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase)
                        .SetUpdate(ignoreTimeScale)
                        .OnComplete(() => onEndHide?.Invoke());
                }
            }
            else
            {
                SetTransformPosition(GetFinalPosition(initialPosition, posStart));
                onEndHide?.Invoke();
            }
        }

        void SetTransformPosition(Vector2 pos)
        {
            if (rect != null)
            {
                rect.anchoredPosition = pos;
            }
            else
            {
                transform.localPosition = pos;
            }
        }
    }
}
