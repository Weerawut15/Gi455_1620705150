using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;
using System;
using UnityEngine.UI;

namespace ChatWebSocketWithJson
{
    public class WebSocketConnection : MonoBehaviour
    {
        
        public GameObject rootConnection;
        public GameObject rootLogin;
        
        public GameObject rootRegister;
        public GameObject rootLobby;
        public GameObject rootCreateRoom;
        public GameObject rootJoinRoom;
        public GameObject rootChat;

        public InputField inputUsername;
        public InputField inputText;
        public Text sendText;
        public Text receiveText;
        
        private WebSocket ws;

        private string tempMessageString;

        public class MessageData
        {
            public string username;
            public string message;
        }
        
        public void Connection()
        {
            rootConnection.SetActive(true);
            rootLogin.SetActive(false);
            rootRegister.SetActive(false);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(false);
            
        }

        public void Login()
        {
            rootConnection.SetActive(false);
            rootLogin.SetActive(true);
            rootRegister.SetActive(false);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(false);
        }
        
        public void Register()
        {
            rootConnection.SetActive(false);
            rootLogin.SetActive(false);
            rootRegister.SetActive(true);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(false);
        }
        
        public void Lobby()
        {
            rootConnection.SetActive(false);
            rootLogin.SetActive(false);
            rootRegister.SetActive(false);
            rootLobby.SetActive(true);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(false);
        }
        
        public void CreateRoom()
        {
            rootConnection.SetActive(false);
            rootLogin.SetActive(false);
            rootRegister.SetActive(false);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(true);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(false);
        }
        
        public void JoinRoom()
        {
            rootConnection.SetActive(false);
            rootLogin.SetActive(false);
            rootRegister.SetActive(false);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(true);
            rootChat.SetActive(false);
        }

        public void Chat()
        {
            string url = $"ws://127.0.0.1:15555/";

            ws = new WebSocket(url);

            ws.OnMessage += OnMessage;

            ws.Connect();

            rootConnection.SetActive(false);
            rootLogin.SetActive(false);
            rootRegister.SetActive(false);
            rootLobby.SetActive(false);
            rootCreateRoom.SetActive(false);
            rootJoinRoom.SetActive(false);
            rootChat.SetActive(true);
        }
        
        
        public void Disconnect()
        {
            if (ws != null)
            {
                ws.Close();
            }
        }
        
        public void SendMessage()
        {
            if (inputText.text == "" || ws.ReadyState != WebSocketState.Open)
            {
                return;
            }

            MessageData newMessageData = new MessageData();
            newMessageData.username = inputUsername.text;
            newMessageData.message = inputText.text;

            string toJsonStr = JsonUtility.ToJson(newMessageData);
            ws.Send(toJsonStr);
            inputText.text = "";
        }

        private void OnDestroy()
        {
            if (ws != null)
                ws.Close();
        }

        private void Update()
        {
            if (string.IsNullOrEmpty(tempMessageString) == false)
            {
                MessageData receiveMessageData = JsonUtility.FromJson<MessageData>(tempMessageString);

                if (receiveMessageData.username == inputUsername.text)
                {
                    sendText.text += receiveMessageData.username + ": " + receiveMessageData.message + "\n";
                    receiveText.text += "\n";
                }

                else
                {
                    receiveText.text += receiveMessageData.username + ": " + receiveMessageData.message + "\n";
                    sendText.text += "\n";
                }
                tempMessageString = "";
            }
        }

        private void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            tempMessageString = messageEventArgs.Data;
            
        }
    }
}


