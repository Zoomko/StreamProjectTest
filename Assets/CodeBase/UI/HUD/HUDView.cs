using Assets.CodeBase.Features.Lamp;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI
{
    public class HUDView : MonoBehaviour
    {
        [SerializeField]
        private Button _menuButton;
        [SerializeField]
        private Button _startBroadcastButton;
        [SerializeField]
        private Button _getCurrentOdometerValueButton;
        [SerializeField]
        private Button _getRandomOdometerValueButton;
        [SerializeField]
        private Toggle _trueToggle;
        [SerializeField]
        private Toggle _falseToggle;
        private StatusLamp _statusLamp;

        public StatusLamp StatusLamp => _statusLamp;
        public Button MenuButton => _menuButton;
        public Button StartBroadcastButton => _startBroadcastButton;
        public Button GetCurrentOdometerValueButton => _getCurrentOdometerValueButton;
        public Button GetRandomOdometerValueButton => _getRandomOdometerValueButton;
        public Toggle TrueToggle => _trueToggle;
        public Toggle FalseToggle => _falseToggle;

        private void Awake()
        {
            _statusLamp = GetComponentInChildren<StatusLamp>();
        }
    }
}
