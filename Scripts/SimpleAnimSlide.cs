using DG.Tweening;
using MyBox;
using System.Collections;
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
        private void Awake()
        {
            rect = GetComponent<RectTransform>();
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
            if(triggerAnim == TimeTriggerAnim.OnEnable)
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

        public override void Show()
        {
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            Vector2 rootPos = rect.anchoredPosition;
            if (!useDefaultSetting)
            {
                rect.anchoredPosition = posStart;
                yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
                rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase);
            }
            else
            {
                if (direction == Direction.Left || direction == Direction.Right)
                {
                    rect.anchoredPosition = new Vector2(posStart_x, rootPos.y);
                    yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
                    rect.DOAnchorPosX(rootPos.x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase);
                }
                else if (direction == Direction.Top || direction == Direction.Bottom) 
                {
                    rect.anchoredPosition = new Vector2(rootPos.x, posStart_y);
                    yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
                    rect.DOAnchorPosX(rootPos.y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase);
                }
            }
        }

        public override void Hide()
        {
            if(!useDefaultSetting)
                rect.DOAnchorPos(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
            else
            {
                if(direction == Direction.Left || direction == Direction.Right)
                    rect.DOAnchorPosX(posStart_x, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
                else if(direction == Direction.Top || direction == Direction.Bottom)
                    rect.DOAnchorPosY(posStart_y, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
            }
        }
    }

    enum Direction
    {
        NotSet = 0, Top = 1, Bottom = 2, Left = 3, Right = 4
    }
}
