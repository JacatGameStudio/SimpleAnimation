using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{

    public class SimpleAnimScale : SimpleAnim
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

        public void Show()
        {
            onStartShow?.Invoke();
            StartCoroutine(Co_ShowAnim());
        }

        IEnumerator Co_ShowAnim()
        {
            yield return new WaitForSeconds(timeDelay > 0 ? timeDelay : 0);
            transform.DOScale(scaleEnd, timeDuration > 0 ? timeDuration : 0.1f).From(scaleStart).SetEase(showEase).OnComplete(() => onEndShow?.Invoke());
        }

        public void Hide()
        {
            onStartHide?.Invoke();
            transform.DOScale(scaleStart, timeDuration > 0 ? timeDuration : 0.1f).From(scaleEnd).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
        }
    }
}
