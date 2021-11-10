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

        [SerializeField] Direction direction;
        RectTransform rect;
        private void Awake()
        {
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

        public override void Show()
        {
            onStartShow?.Invoke();
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            rect.anchoredPosition = posStart;
            yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
             rect.DOAnchorPos(posEnd, timeDuration > 0 ? timeDuration : 0.1f).SetEase(showEase).OnComplete(() => onEndShow?.Invoke());
        }

        public override void Hide()
        {
            transform.DOScale(posStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
        }
    }

    enum Direction
    {
        NotSet = 0, Top = 1, Bottom = 2, Left = 3, Right = 4
    }
}
