using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sending : MonoBehaviour
{
    public Connection con;
    void Start()
    {
        con = GetComponent<Connection>();
    }

    public void TestSend()
    {
        string mess = "{«operation»:\r\n«getCurrentOdometer»}";
        con.SendText(mess);
    }
    void Update()
    {
        
    }
    public void SendRandom()
    {
        SendPacket packet=new SendPacket("odometer_val", Random.Range(0,1000));
        print("Sending"+packet.value.ToString());
        con.SendText(JsonUtility.ToJson(packet));
    }
}
public struct SendPacket
{
    public string operation;
    public float value;
    public SendPacket(string operation, float value)
    {
        this.operation = operation;
        this.value = value;
    }
}
