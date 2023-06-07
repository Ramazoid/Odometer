using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Appearance App;

    void Start()
    {
        App = GetComponent<Appearance>();
        App.TurnOff();
    }

    public void ShowPanel()
    {
        App.state = "ShowPanel";
    }
    public void HidePanel()
    {
        App.state = "HidePanel";
    }

    void Update()
    {
        
    }
}
