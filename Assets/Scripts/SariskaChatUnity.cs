using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Phoenix;
using WebSocketSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net;

public sealed class BasicLogger : Phoenix.ILogger
{
    public void Log(Phoenix.LogLevel level, string source, string message)
    {
        Console.WriteLine("[{0}]: {1} - {2}", level, source, message);
    }
}

public class SariskaChatUnity : MonoBehaviour
{

    WebSocketHelper webSocketHelper;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting Token Generation");
        string token = GenerateToken.GetToken("dipak").token;
        Debug.Log(token);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GeneralIntegrationTest()
    {
        // SetUp
        var onOpenCount = 0;

        void OnOpenCallback()
        {
            onOpenCount++;
        }

        List<string> onErrorData = new();

        void OnErrorCallback(string message)
        {
            onErrorData.Add(message);
        }

        // connecting is synchronous as implemented above
        var socketAddress = $"wss://api.sariska.io/api/v1/messaging/websocket/websocket";
        var socketFactory = new WebSocketHelper.WebsocketSharpFactory();
        var socket = new Socket(
            socketAddress,
            null,
            socketFactory,
            new Socket.Options(new JsonMessageSerializer())
            {
                ReconnectAfter = _ => TimeSpan.FromMilliseconds(200),

            }
            );

        socket.OnOpen += OnOpenCallback;
        socket.OnError += OnErrorCallback;

        socket.Connect();

    }
}
