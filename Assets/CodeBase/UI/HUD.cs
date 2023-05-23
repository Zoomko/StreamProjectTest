using Assets.CodeBase.App;
using Assets.CodeBase.Features.Lamp;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField]
        private  Button _menuButton;
        [SerializeField]
        private Button _startBroadcastButton;
        [SerializeField]
        private Button _getCurrentOdometerValueButton;
        [SerializeField]
        private Button _getRandomOdometerValueButton;

        private StatusLamp _statusLamp;
        private WebSocketClient _client;
        private IResourcesProvider _resourcesProvider;

        public StatusLamp StatusLamp => _statusLamp;
        public Button MenuButton => _menuButton;
        public Button StartBroadcastButton => _startBroadcastButton;
        public Button GetCurrentOdometerValueButton => _getCurrentOdometerValueButton;
        public Button GetRandomOdometerValueButton => _getRandomOdometerValueButton;

        private void Awake()
        {
            _statusLamp = GetComponentInChildren<StatusLamp>();
        }

        public void Constructor(WebSocketClient webSocketClient, IResourcesProvider resourcesProvider)
        {
            _statusLamp.Constructor(resourcesProvider, webSocketClient);
        }
    }
}
