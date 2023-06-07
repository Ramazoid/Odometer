using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using NativeWebSocket;
using UnityEngine.UI;

public class Connection : MonoBehaviour
{
    public WebSocket websocket;
    public string ServerAddress;
        public InputField IFServerAddress;
    public string ServerPort;
    public InputField IFServerPort;
    public string StreamAddress;
    public InputField IFStreamAfddress;

    public Action<string> ParseAnswer;

    public void Connect()
    {
        Indicator.StartBlinking();
        websocket = new WebSocket("ws://185.246.65.199:9090/ws");
    }
    async void Start()
    {
        IFServerAddress.text = ServerAddress;
        IFServerPort.text = ServerPort;
        IFStreamAfddress.text = StreamAddress;
        Indicator.StartBlinking();
        websocket = new WebSocket("ws://185.246.65.199:9090/ws");

        websocket.OnOpen += () =>
        {
            Debug.Log("Connection open!");
            Indicator.SetConnected(true);
            Indicator.StopBlinking();

        };

        websocket.OnError += (e) =>
        {
            Debug.Log("Error! " + e);
        };

        websocket.OnClose += (e) =>
        {
            Debug.Log("Connection closed!");
            Indicator.SetConnected(false);
            Connect();
        };

        websocket.OnMessage += (bytes) =>
        {
            Debug.Log("OnMessage!");
            

            // getting the message as a string
             var message = System.Text.Encoding.UTF8.GetString(bytes);
            print("Message:" + message);
             ParseAnswer(message);
             
        };

        // Keep sending messages at every 0.3s
        InvokeRepeating("SendWebSocketMessage", 0.0f, 0.3f);

        // waiting for messages
        await websocket.Connect();
    }

    void Update()
    {
#if !UNITY_WEBGL || UNITY_EDITOR
        if (websocket != null)
        {
            websocket.DispatchMessageQueue();
        }
#endif
    }

    async void SendWebSocketMessage()
    {
        if (websocket.State == WebSocketState.Open)
        {
            // Sending bytes
            await websocket.Send(new byte[] { 10, 20, 30 });

            // Sending plain text
            await websocket.SendText("plain text message");
        }
    }

    public async void SendText(string mess)
    {
       await websocket.SendText(mess);
         }
    private async void OnApplicationQuit()
    {
        await websocket.Close();
    }

}