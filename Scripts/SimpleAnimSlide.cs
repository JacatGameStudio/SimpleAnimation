using DG.Tweening;
using MyBox;
using System;
using UnityEngine;
namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimSlide : SimpleAnimBase
    {
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] Vector2 posStart;
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] Vector2 posEnd;

        [ConditionalField(nameof(useDefaultSetting), false)] [SerializeField] Direction direction;
        [ConditionalField(nameof(direction), true, Direction.Bottom, Direction.Top, Direction.NotSet)] [SerializeField] float posStart_x;
        [ConditionalField(nameof(direction), true, Direction.Left, Direction.Right, Direction.NotSet)] [SerializeField] float posStart_y;

        RectTransform rect;
        Vector2 rootPos;
        private void Awake()
        {
            rect = GetComponent<RectTransform>();
            rootPos = rect.anchoredPosition;
            if (useDefaultSetting)
            {
                //rect = GetComponent<RectTransform>();
                //posEnd = rect.anchoredPosition;  

                //if(direction == Direction.Left)
                //{
                //    float distance = rect.rect.xMin + Screen.width / 2 + rect.rect.width / 2;
                //    posStart = new Vector2(rect.anchoredPosition.x - distance - 50, rect.anchoredPosition.y); // sai số 50
                //}
                //else if (direction == Direction.Right)
                //{
                //    float distance = - rect.rect.xMax + Screen.width / 2 + rect.rect.width / 2;
                //    posStart = new Vector2(rect.anchoredPosition.x + distance + 50, rect.anchoredPosition.y); // sai số 50
                //}
                //else if (direction == Direction.Top)
                //{
                //    float distance = -rect.rect.yMax + Screen.height / 2 + rect.rect.width / 2;
                //    posStart = new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y + distance + 50); // sai số 50
                //}
                //else if (direction == Direction.Bottom)
                //{
                //    float distance = -rect.rect.xMin + Screen.width / 2 + rect.rect.width / 2;
                //    posStart = new Vector2(rect.anchoredPosition.x , rect.anchoredPosition.y - distance - 50); // sai số 50
                //}

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
                if (!useDefaultSetting)
                {
                    rect.anchoredPosition = posStart;
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
                }
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                    {
                        rect.anchoredPosition = new Vector2(posStart_x, rootPos.y);
                        rect.DOAnchorPosX(rootPos.x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
                    }
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                    {
                        rect.anchoredPosition = new Vector2(rootPos.x, posStart_y);
                        rect.DOAnchorPosY(rootPos.y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0);
                    }
                }
            }
            else
            {
                if (!useDefaultSetting)
                {
                    rect.anchoredPosition = posEnd;
                }
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                    {
                        rect.anchoredPosition = new Vector2(rootPos.x, rect.anchoredPosition.y);
                    }
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                    {
                        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rootPos.y);
                    }
                }
            }
        }

        public override void Show(Action onEndStart, bool immediately = false)
        {
            if (!immediately)
            {
                if (!useDefaultSetting)
                {
                    rect.anchoredPosition = posStart;
                    rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
                }
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                    {
                        rect.anchoredPosition = new Vector2(posStart_x, rootPos.y);
                        rect.DOAnchorPosX(rootPos.x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
                    }
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                    {
                        rect.anchoredPosition = new Vector2(rootPos.x, posStart_y);
                        rect.DOAnchorPosY(rootPos.y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).SetDelay(timeDelay > 0 ? timeDelay : 0).OnComplete(() => onEndStart?.Invoke());
                    }
                }
            }
            else
            {
                if (!useDefaultSetting)
                {
                    rect.anchoredPosition = posEnd;
                    onEndStart?.Invoke();
                }
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                    {
                        rect.anchoredPosition = new Vector2(rootPos.x, rect.anchoredPosition.y);
                        onEndStart?.Invoke();
                    }
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                    {
                        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, rootPos.y);
                        onEndStart?.Invoke();
                    }
                }
            }
        }
        public override void Hide(bool immediately = false)
        {
            if (!immediately)
            {
                if (!useDefaultSetting)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                        rect.DOAnchorPosX(posStart_x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                        rect.DOAnchorPosY(posStart_y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                }
            }
            else
            {
                if (!useDefaultSetting)
                    rect.anchoredPosition = posStart;
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                        rect.anchoredPosition = new Vector2(posStart_x, rect.anchoredPosition.y);
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, posStart_y);
                }
            }
        }


        public override void Hide(Action onEndHide, bool immediately = false)
        {
            if (!immediately)
            {
                if (!useDefaultSetting)
                    rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                        rect.DOAnchorPosX(posStart_x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                        rect.DOAnchorPosY(posStart_y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
                }
            }
            else
            {
                if (!useDefaultSetting)
                {
                    rect.anchoredPosition = posStart;
                    onEndHide?.Invoke();
                }

                else
                {
                    if (direction == Direction.Left || direction == Direction.Right)
                    {
                        rect.anchoredPosition = new Vector2(posStart_x, rect.anchoredPosition.y);
                        onEndHide?.Invoke();
                    }
                    else if (direction == Direction.Top || direction == Direction.Bottom)
                    {
                        rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, posStart_y);
                        onEndHide?.Invoke();
                    }
                }
            }
        }
    }

    enum Direction
    {
        NotSet = 0, Top = 1, Bottom = 2, Left = 3, Right = 4
    }
}
