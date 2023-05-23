using Assets.CodeBase.App;
using Assets.CodeBase.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Features.Lamp
{
    public class StatusLamp:MonoBehaviour
    {        
        private ConnectionStatus _connectionStatus;
        private WebSocketClient _websocketClient;
        private Image _image;
        private Color _onlineColor;
        private Color _offlineColor;       
        private float _changeColorTime;   
        
        public void Constructor(IResourcesProvider resourceProvider, WebSocketClient webSocketClient)
        {       
            _changeColorTime = resourceProvider.AppSettings.ChangeColorTime;
            _websocketClient = webSocketClient;
            SubscribeToEvents();
        }

        private void Awake()
        {
            _image = GetComponent<Image>();
            _onlineColor = Color.green;
            _offlineColor = Color.red;
            _image.color = _offlineColor;
            _connectionStatus = ConnectionStatus.Offline;
        }

        private void OnDestroy()
        {
            UnsubscribeToEvents();
        }

        public void OnConnected()
        {
            _connectionStatus = ConnectionStatus.Online;
            StopAllCoroutines();
            StartCoroutine(ChangeStatusColor());
        }

        public void OnDisconnected()
        {
            if (_connectionStatus == ConnectionStatus.Online)
            {
                _connectionStatus = ConnectionStatus.Offline;
                StopAllCoroutines();
                StartCoroutine(ChangeStatusColor());
            }
        }

        private IEnumerator ChangeStatusColor()
        {
            Color targetColor = GetTargetColor();

            yield return ChangeLampColor(Color.black);
            yield return ChangeLampColor(targetColor);

            if(_connectionStatus == ConnectionStatus.Online)
            {
                StartCoroutine(PulsingStatusColor());
            }
        }

        private IEnumerator PulsingStatusColor()
        {
            var fadingColor = _onlineColor * 0.5f;
            while (_connectionStatus == ConnectionStatus.Online)
            {
                _image.color = Color.Lerp(_onlineColor, fadingColor, Mathf.Cos(Time.time));
                yield return null;
            }
        }

        private IEnumerator ChangeLampColor(Color targetColor)
        {
            Color startColor = _image.color;
            var timer = 0f;
            var timeToStop = _changeColorTime / 2;
            while (timer < timeToStop)
            {
                timer += Time.deltaTime;
                _image.color = Color.Lerp(startColor, targetColor, timer / timeToStop);
                yield return null;
            }
        }
        
        private Color GetTargetColor()
        {
            Color targetColor;
            if (_connectionStatus == ConnectionStatus.Online)
                targetColor = _onlineColor;
            else
                targetColor = _offlineColor;
            return targetColor;
        }

        private void SubscribeToEvents()
        {
            _websocketClient.Connected += OnConnected;
            _websocketClient.Disconnected += OnDisconnected;
        }

        private void UnsubscribeToEvents()
        {
            _websocketClient.Connected -= OnConnected;
            _websocketClient.Disconnected -= OnDisconnected;
        }

    }
}
