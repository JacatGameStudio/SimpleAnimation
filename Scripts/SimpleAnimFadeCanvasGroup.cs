using DG.Tweening;
using MyBox;
using System.Collections;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    [RequireComponent(typeof(CanvasGroup))]

    public class SimpleAnimFadeCanvasGroup : SimpleAnim
    {
        [ConditionalField(nameof(useDefault), true)] [SerializeField] float opacityStart = 0;
        [ConditionalField(nameof(useDefault), true)] [SerializeField] float opacityEnd = 1;

        CanvasGroup canvasGroup;
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
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
            canvasGroup.DOFade(opacityEnd, timeDuration > 0 ? timeDuration : 0.1f).From(opacityStart).SetEase(showEase).OnComplete(() => onEndShow?.Invoke());
        }

        public void Hide()
        {
            onStartHide?.Invoke();
            canvasGroup.DOFade(opacityStart, timeDuration > 0 ? timeDuration : 0.1f).From(opacityEnd).SetEase(hideEase).OnComplete(() => onEndHide?.Invoke());
        }
    }
}
