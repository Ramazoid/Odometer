using System;
using UnityEngine;
using UnityEngine.UI;

public class Logger : MonoBehaviour
{
    public Text LogText;
    public int num;
    public void INIT()
    {
        //System.Console.SetOut(new DebugLogWriter(LogText));
        Application.logMessageReceived += NewLog;

    }

    private void NewLog(string condition, string stackTrace, LogType type)
    {
        LogText.text += "\n" + stackTrace;
    }
}

