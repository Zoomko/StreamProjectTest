using Assets.CodeBase.App;
using Assets.CodeBase.DTO.Responses;
using Assets.CodeBase.Odometer;
using NativeWebSocket;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class WebSocketClient : ITickable, IDisposable
{
    public Action Connected;
    public Action Disconnected;

    private readonly OdometerController _odometerController;
    private readonly IResourcesProvider _resourcesProvider;
    private WebSocket _webSocket;    

    private bool _isInSession = false;

    public WebSocketClient(OdometerController odometerController, IResourcesProvider resourcesProvider)
    {
        _odometerController = odometerController;
        _resourcesProvider = resourcesProvider;
    }

    public void CreateWebSocket()
    {
        var address = "ws://" + _resourcesProvider.Config.ToString() + "/ws";
        _webSocket = new WebSocket(address);
        _webSocket.OnOpen += OnOpen;
        _webSocket.OnError += OnError;
        _webSocket.OnClose += OnClose;
        _webSocket.OnMessage += OnMessage;
    }

    public async void Connect()
    {
        _isInSession = true;
        await _webSocket.Connect();
    }

    public async void Disconnect()
    {
        _isInSession = false;
        await _webSocket.Close();
    }

    public async void Send(string text)
    {
        await _webSocket.SendText(text);
    }

    public void Tick()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (_webSocket != null)
        {
            _webSocket.DispatchMessageQueue();
        }
#endif
    }

    public void Dispose()
    {
        Disconnect();
    }

    private void OnOpen()
    {
        Debug.Log("Connection open!");
        Connected?.Invoke();
    }

    private void OnMessage(byte[] data)
    {
        var message = System.Text.Encoding.UTF8.GetString(data);
        var response = JsonConvert.DeserializeObject<ResponseDTO>(message);
        var value = response.Value;
        var floatValue = float.Parse(value, CultureInfo.InvariantCulture);
        _odometerController.SetValue(floatValue);

        Debug.Log("OnMessage! " + message);
    }

    private async void OnClose(WebSocketCloseCode closeCode)
    {
        Debug.Log("Connection closed!");
        Disconnected?.Invoke();

        if (_isInSession)
        {
            await Task.Delay(_resourcesProvider.AppSettings.TimeToReconnect * 1000);
            await _webSocket.Connect();
        }
    }

    private void OnError(string errorMsg)
    {
        Debug.Log("Error! " + errorMsg);
    }
}
