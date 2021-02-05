 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
 using WebSocketSharp;

namespace ProgramChat
{
    public class WebsocketConnection : MonoBehaviour
    {
        string username;
        private string message;
        private string temp;
        public Text chatBox;
        public Transform chatPanel;
        public GameObject newChat;

        public Text cheatBox2;
        
        [SerializeField]private InputField textInput;
        [SerializeField]private InputField usernameInput;
        private WebSocket websocket;
        // Start is called before the first frame update
        void Start()
        {
            //
            websocket = new WebSocket("ws://127.0.0.1:15500/");

            websocket.OnMessage += OnMessage;
            
            websocket.Connect();

            chatBox.text = string.Empty;

            //webSocket.Send("I'm coming here.");
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                message = textInput.text;
                username = usernameInput.text;
                Debug.Log(username  + " " + message);
                string newMessage = $"{username} : {message}";
                if (websocket.ReadyState == WebSocketState.Open)
                {
                    websocket.Send(newMessage);
                }
            }
            else
            {
                
            }
        }

        private void OnDestroy()
        {
            if (websocket != null)
            {
                websocket.Close();
            }
        }

        public void OnMessage(object sender, MessageEventArgs messageEventArgs)
        {
            Debug.Log("Receive nsg : " + messageEventArgs.Data);
            temp = messageEventArgs.Data;
            chatBox.text += temp + "\n";
        }
    }

}

