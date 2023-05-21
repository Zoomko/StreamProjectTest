using Assets.CodeBase.App;
using Assets.CodeBase.Services;
using NativeWebSocket;
using UnityEngine;

public class WebSocketClient
{
    private readonly ILoadSaveDataFormat _loadSaveDataFormat;
    private readonly WebSocket _webSocket;

    public WebSocketClient(ILoadSaveDataFormat loadSaveDataFormat)
    {
        _loadSaveDataFormat = loadSaveDataFormat;
        var connectInfo = _loadSaveDataFormat.Load<Config>(Paths.ConfigPath);
        _webSocket = CreateWebSocket(connectInfo.ServerAddress,connectInfo.ServerPort);
    }

    private WebSocket CreateWebSocket(string IP, string port)
    {
        var webSocket = new WebSocket("ws://"+IP+":"+port+"/ws");
        webSocket.OnOpen += OnOpen;
        webSocket.OnError += OnError;
        webSocket.OnClose += OnClose;
        webSocket.OnMessage += OnMessage;
        return webSocket;
    }

    public void Connect()
    {
        _webSocket.Connect();
    }

    public void Disconnect()
    {
        _webSocket.Close();
    }
    
    public void Send(string text)
    {
        _webSocket.SendText(text);
    }

    private void OnOpen()
    {
        Debug.Log("Connection open!");
    }

    private void OnMessage(byte[] data)
    {
        var message = System.Text.Encoding.UTF8.GetString(data);
        Debug.Log("OnMessage! " + message);
    }

    private void OnClose(WebSocketCloseCode closeCode)
    {
        Debug.Log("Connection closed!");
    }

    private void OnError(string errorMsg)
    {
        Debug.Log("Error! " + errorMsg);
    }    
}
