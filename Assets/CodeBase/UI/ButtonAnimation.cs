using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.CodeBase.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler
    {
        private Button _button;
        private Vector3 _startPosition;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _startPosition = transform.position;
            _button.onClick.AddListener(OnClick);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            LeanTween.move(gameObject, _startPosition + Vector3.up * 5f, 0.2f);
            LeanTween.move(gameObject, _startPosition, 0.2f).setDelay(0.2f);
        }

        private void OnClick()
        {
            LeanTween.scale(gameObject, Vector3.one * 0.8f, 0.2f).setEase(LeanTweenType.easeInOutBounce);
            LeanTween.scale(gameObject, Vector3.one, 0.2f).setDelay(0.2f);
        }
    }
}
