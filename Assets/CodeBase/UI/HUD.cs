using Assets.CodeBase.App;
using Assets.CodeBase.Features.Lamp;
using System.Reflection.Emit;
using UnityEngine;

namespace Assets.CodeBase.UI
{
    public class HUD : MonoBehaviour
    {
        private WebSocketClient _client;
        private IResourcesProvider _resourcesProvider;

        private StatusLamp _statusLamp;
        public StatusLamp StatusLamp => _statusLamp;

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
