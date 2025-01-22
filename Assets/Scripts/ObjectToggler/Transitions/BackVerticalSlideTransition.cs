using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ObjectToggler.Transitions
{
    [CreateAssetMenu(menuName = "ObjectTogglerMenu/Transitions/BackVerticalSlideTransition")]
    public class BackVerticalSlideTransition : AbstractTogglerTransition
    {
        [SerializeField, Min(0f)] private float _duration = 0.2f;

        private EventSystem _eventSystem = null;
        private Vector3 _initialAncoredPosition;

        public override void BeforeTransition(Transform from, Transform to)
        {
            if (_eventSystem == null)
            {
                _eventSystem = FindObjectOfType<EventSystem>();
            }

            _eventSystem.enabled = false;

            var toRectTransform = to.GetComponent<RectTransform>();
            var fromRectTransform = from.GetComponent<RectTransform>();
            _initialAncoredPosition = fromRectTransform.anchoredPosition;
            var prevAnc = toRectTransform.anchoredPosition;
            prevAnc.y = toRectTransform.rect.height;
            toRectTransform.anchoredPosition = prevAnc;
        }

        public override async Task Transition(Transform from, Transform to)
        {
            var fromRectTransform = from.GetComponent<RectTransform>();
            var toRectTransform = to.GetComponent<RectTransform>();

            var taskCompletionSource = new TaskCompletionSource<object>();

            DOTween.To(() => toRectTransform.anchoredPosition.y, (newValue) =>
            {
                var newAnchoredPosition = fromRectTransform.anchoredPosition;
                newAnchoredPosition.y = newValue - toRectTransform.rect.height;
                fromRectTransform.anchoredPosition = newAnchoredPosition;

                newAnchoredPosition = toRectTransform.anchoredPosition;
                newAnchoredPosition.y = newValue;
                toRectTransform.anchoredPosition = newAnchoredPosition;
            }, 0, _duration).OnComplete(() => { taskCompletionSource.SetResult(null); });

            await taskCompletionSource.Task;
        }

        public override void AfterTransition(Transform from, Transform to)
        {
            from.GetComponent<RectTransform>().anchoredPosition = _initialAncoredPosition;
            _eventSystem.enabled = true;
        }
    }
}