using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebSocketSharp;

public class Loginmenu : MonoBehaviour
{
    private WebSocket TwebSocket;
    public InputField Port;
    public InputField IP;
    
    public void Cheak() {
        string PortC = "15500";
        string IpC = "127.0.0.1";
        
        if (IP.text.Contains(IpC) && Port.text.Contains(PortC)) {
            SceneManager.LoadScene("testS");
        }
        
        else {
            Debug.Log("Fail to join chat");
        }
    }
}
