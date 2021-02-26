using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonFormat : MonoBehaviour
{
    class  MessageJsonData
    {
        public string username;
        public string message;
        public string color;
        
    }

    class CharacterStatus
    {
        public float hp;
        public float mp;
        public float atk;
        public float def;
        public int money;
    }

    // Start is called before the first frame update
    void Start()
    {
        string jsonStr = "{\"username\":\"inwza007\",\"message\":\"ioioioio\",\"Color\":\"red\"}";

        MessageJsonData messageJsonData = JsonUtility.FromJson<MessageJsonData>(jsonStr);
        
        Debug.Log(messageJsonData.username);
        Debug.Log(messageJsonData.message);
        Debug.Log(messageJsonData.color);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
