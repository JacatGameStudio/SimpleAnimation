using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(SimpleAnimObject))]
    public class SimpleAnimScale : SimpleAnimBase
    {
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float scaleStart = 0;
        [ConditionalField(nameof(useDefaultSetting), true)] [SerializeField] float scaleEnd = 1;

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
            base.Show();
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
            transform.DOScale(scaleEnd, timeDuration > 0 ? timeDuration : 0.1f).From(scaleStart).SetEase(showEase);
        }

        public override void Hide()
        {
            base.Hide();
            transform.DOScale(scaleStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase);
        }
    }
}
