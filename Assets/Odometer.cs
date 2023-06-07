using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Odometer : MonoBehaviour
{
    public Text OdoVal;
    public int ToValue=0;
    public float CurrentValue=0;
    public string rotatestate;
    public int CangeSpeed;
    public int MaxVal=1000;
    public int CalculatedMax;
    public RectTransform arrowAnchor;
    public float maxArrowAngle;

    public float ZeroAngle;

    void Start()
    {
        ZeroAngle = arrowAnchor.rotation.eulerAngles.z;
        arrowAnchor.rotation = Quaternion.Euler(0, 0, 125.880302f);
        maxArrowAngle = arrowAnchor.rotation.eulerAngles.z;
        arrowAnchor.rotation = Quaternion.Euler(0, 0, ZeroAngle);
        CurrentValue = 0;
        rotatestate = "WaitData";
    }

    // Update is called once per frame
    void Update()
    {
        float newZ;

        if (MaxVal != 0)
        {
            switch (rotatestate)
            {
                case "FirstArc":
            newZ = ZeroAngle + (maxArrowAngle - ZeroAngle) * (ToValue/2) / MaxVal;
                    CurrentValue = ToValue;
                    arrowAnchor.rotation = Quaternion.Lerp(arrowAnchor.rotation, Quaternion.Euler(0, 0, newZ), 0.01f);
                    if( Quaternion.Angle(arrowAnchor.rotation, Quaternion.Euler(0, 0, newZ))==0)
                        rotatestate = "LastArc";
                    break;
                case "LastArc":
                    newZ = ZeroAngle + (maxArrowAngle - ZeroAngle) * (ToValue ) / MaxVal;
                    CurrentValue = ToValue;
                    arrowAnchor.rotation = Quaternion.Lerp(arrowAnchor.rotation, Quaternion.Euler(0, 0, newZ), 0.01f);
                    if (Quaternion.Angle(arrowAnchor.rotation, Quaternion.Euler(0, 0, newZ)) == 0)
                        rotatestate = "WaitData";
                    break;
            }
        }
    }
        public void ParseAnswer(string answer)
    {
        OdoData data = JsonUtility.FromJson<OdoData>(answer);
        
        string toval =((int)data.value).ToString();
        toval=toval.Substring(toval.Length - 3);
        ToValue=int.Parse(toval);

        rotatestate = "FirstArc";
    }
}

public class OdoData
{
    public string operation;
    public float value;
}