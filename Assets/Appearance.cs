using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appearance : MonoBehaviour
{
    private RectTransform RT;
    public string state;
    public  CanvasGroup PanelCG;

    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case "1grow":
                RT.localScale += Vector3.one / 20;
                if (RT.localScale.x>=1)
                    state = "2shrink";
                break;
            case "2shrink":
                RT.localScale -= Vector3.one / 10;
                if (RT.localScale.x <=0.8f)
                    state = "wait";
                break;

            case "ShowPanel":
                if (PanelCG.alpha < 1)
                    PanelCG.alpha += 0.01f;
                else
                    state = "Wait";
                break;

            case "HidePanel":
                    if (PanelCG.alpha >0)
                    PanelCG.alpha -= 0.01f;
                else
                    state = "Wait";
                break;
        }
    }
    public void HoverIN()
    {
        RT.localScale = Vector3.one * 1.2f;
    }
    public void HoverOUT()
    {
        RT.localScale = Vector3.one;
    }

    public  void TurnOff()
    {
        RT = GetComponent<RectTransform>();
        RT.localScale = Vector3.one / 1000;
        PanelCG.alpha = 0;
        state = "1grow";

    }
}
