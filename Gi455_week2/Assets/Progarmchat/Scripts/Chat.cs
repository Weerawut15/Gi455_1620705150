/*โค๊ตทดลองจากในเน็ต เลิกใช้แล้ว https://www.youtube.com/watch?v=IRAeJgGkjHk ลิ้งที่ดูมา
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Chat : MonoBehaviour
{
     public InputField username;

     public int maxMessages = 100;

     public GameObject chatPanel, textObject;
     public InputField chatBox;
     
     [SerializeField] 
     List<Message> messageList = new List<Message>();

     void Start() {
          
     }
     void Update()
     {

          if (Input.GetKeyDown(KeyCode.Return))
          {
               Debug.Log(username.text);
          }
          
          if (chatBox.text != "")
          {
               if (Input.GetKeyDown(KeyCode.Return))
               {
                    SendMessageTochat(username.text + ": "+ chatBox.text, Message.MessageType.playerMessage);
                    chatBox.text = "";
               }
          }
          else
          {
               if(!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
                    chatBox.ActivateInputField();
          }
          
          if (!chatBox.isFocused)
          {
               if (Input.GetKeyDown(KeyCode.Space))
               {
                    SendMessageTochat("You presed space bar!" ,Message.MessageType.info);
                    Debug.Log("Space");
               }
          }
     }
          
          public void SendMessageTochat(string text, Message.MessageType messageType)
          {

               if (messageList.Count >= maxMessages)
               {
                    Destroy(messageList[0].textObject.gameObject);
                    messageList.Remove(messageList[0]);
               }

               Message newMessage = new Message();

               newMessage.text = text;

               GameObject newText = Instantiate(textObject, chatPanel.transform);

               newMessage.textObject = newText.GetComponent<Text>();

               newMessage.textObject.text = newMessage.text;

               messageList.Add(newMessage);
          }
     }
     [System.Serializable]
     public class Message
     {
          public string text;
          public Text textObject;
          public enum  MessageType
          {
               playerMessage,
               info
          }
     }
     */
