using TMPro;
using UnityEngine;

namespace Assets.CodeBase.App
{
    public class Notifyer : MonoBehaviour
    {
        [SerializeField]
        private GameObject _messagePanel;
        [SerializeField]
        private TextMeshProUGUI _textMesh;

        private void Awake()
        {
            Close();
        }

        public void Open()
        {
            if (_messagePanel != null)
                _messagePanel.SetActive(true);
        }

        public void Close()
        {
            if (_messagePanel != null)
                _messagePanel.SetActive(false);
        }

        public void SetMessage(string message)
        {
            _textMesh.text = message;
        }
    }
}