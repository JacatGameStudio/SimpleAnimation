using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{

    public class SimpleAnimScale : SimpleAnimBase
    {
        [ConditionalField(nameof(useDefault), true)] [SerializeField] float scaleStart = 0;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] float scaleEnd = 1;

        private void OnEnable()
        {
            gameObject.SetActive(enableOnAwake);

            if (timeFireShowAnim == TimeFireShowAnim.OnEnable)
            {
                Show();
            }
        }
        private void Start()
        {
            if (timeFireShowAnim == TimeFireShowAnim.OnStart)
            {
                Show();
            }
        }

        private void OnDisable()
        {
            if (timeFireHideAnim == TimeFireHideAnim.OnDisable)
            {
                Hide();
            }
        }

        private void OnDestroy()
        {
            if (timeFireHideAnim == TimeFireHideAnim.OnDisable)
            {
                Hide();
            }
        }

        public override void Show()
        {
            base.Show();
            onStartShow?.Invoke();
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
            transform.DOScale(scaleEnd, timeDuration > 0 ? timeDuration : 0.1f).From(scaleStart).SetEase(showEase).OnComplete(() => onEndShow?.Invoke());
        }

        public override void Hide()
        {
            base.Hide();
            onStartHide?.Invoke();
            transform.DOScale(scaleStart, timeDuration > 0 ? timeDuration : 0.1f).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
        }
    }
}
