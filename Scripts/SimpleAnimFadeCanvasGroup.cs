using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(CanvasGroup))]
    [RequireComponent(typeof(SimpleAnimObject))]

    public class SimpleAnimFadeCanvasGroup : SimpleAnimBase
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

        public override void Show()
        {
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
            canvasGroup.DOFade(opacityEnd, timeDuration > 0 ? timeDuration : 0.1f).From(opacityStart).SetEase(showEase);
        }

        public override void Hide()
        {
            canvasGroup.DOFade(opacityStart, timeDuration > 0 ? timeDuration : 0.1f).From(opacityEnd).SetEase(hideEase);
        }
    }
}
