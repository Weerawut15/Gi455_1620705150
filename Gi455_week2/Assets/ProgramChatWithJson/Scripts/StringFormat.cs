using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringFormat : MonoBehaviour
{
    public class  MessageData
    {
        public string username;
        public string message;
        public string colorName;
    }

    void Start()
    {
        string receiveMessage = "inwza007#hello world#red";

        string[] messageDataSplit = receiveMessage.Split('#');

        string jsonStr = "(";

        for (int i = 0; i < messageDataSplit.Length; i++)
        {
            jsonStr += messageDataSplit[i] + ",";
        }

        jsonStr += "}";
        
        Debug.Log(jsonStr);
        
        MessageData messageData = new MessageData();
        messageData.username = messageDataSplit[0];
        messageData.message = messageDataSplit[1];
        messageData.colorName = messageDataSplit[2];

        if (messageData.username == "inwza0087")
        {
            //do somthing
            ShowMessage(messageData.message);
        }
        
    }

    void ShowMessage(string message)
        {
            
        }

    // Update is called once per frame
    void Update()
    {
        
    }
}