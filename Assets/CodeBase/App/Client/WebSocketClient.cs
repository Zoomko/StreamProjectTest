using Assets.CodeBase.App;
using Assets.CodeBase.App.Client;
using Assets.CodeBase.Services;
using NativeWebSocket;
using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class WebSocketClient : ITickable, IDisposable
{
    public Action Connected;
    public Action Disconnected;

    private readonly IPersistentDataService _persistentDataService;
    private readonly MessageDispatcher _messageDispatcher;
    private readonly Notifyer _notifyer;
    private readonly IResourcesProvider _resourcesProvider;
    private WebSocket _webSocket;
    private string _address;

    private bool _connectionIsOpen = false;
    private bool _isInSession = false;

    public WebSocketClient(IResourcesProvider resourcesProvider,
                           IPersistentDataService persistentDataService,
                           MessageDispatcher messageDispatcher,
                           Notifyer notifyer)
    {
        _resourcesProvider = resourcesProvider;
        _persistentDataService = persistentDataService;
        _messageDispatcher = messageDispatcher;
        _notifyer = notifyer;
    }

    public void CreateWebSocket()
    {
        _address = GetAddress();
        _webSocket = new WebSocket(_address);
        SubscribeToEvents();
    }

    public async void RecreateWebSocketWithNewAddress()
    {
        var newAddress = GetAddress();
        if(_address != newAddress)
        {
            _address = newAddress;
            await _webSocket.Close();
            UnsubscribeToEvents();
            CreateWebSocket();
            await _webSocket.Connect();
        }
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

    private string GetAddress() 
        => "ws://" + _persistentDataService.Config.ServerSettings.ToString() + "/ws";

    private void SubscribeToEvents()
    {
        _webSocket.OnOpen += OnOpen;
        _webSocket.OnError += OnError;
        _webSocket.OnClose += OnClose;
        _webSocket.OnMessage += OnMessage;
    }

    private void UnsubscribeToEvents()
    {
        _webSocket.OnOpen -= OnOpen;
        _webSocket.OnError -= OnError;
        _webSocket.OnClose -= OnClose;
        _webSocket.OnMessage -= OnMessage;
    }

    private void OnOpen()
    {
        Debug.Log("Connection open!");
        _connectionIsOpen = true;
        _notifyer.Close();
        Connected?.Invoke();
    }

    private void OnMessage(byte[] data)
    {
        _messageDispatcher.OnMessageComes(data);
    }

    private async void OnClose(WebSocketCloseCode closeCode)
    {
        Debug.Log("Connection closed!");
        _connectionIsOpen = false;
        _notifyer.Open();
        _notifyer.SetMessage("Connection lost, trying to reconnect");
        Disconnected?.Invoke();

        if (_isInSession)
        {
            await Task.Delay(_resourcesProvider.AppSettings.TimeToReconnect * 1000);
            if(!_connectionIsOpen)
                await _webSocket.Connect();
        }
    }

    private void OnError(string errorMsg)
    {
        Debug.Log("Error! " + errorMsg);
    }
}
