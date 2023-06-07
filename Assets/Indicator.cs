using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Indicator : MonoBehaviour
{
    public Image indiImage;
    public Sprite OnSprite;
    public Sprite OffSprite;
    public static Indicator INST;
   
    public GameObject blinkingText;
    public bool blink = false;
    private bool showBlink;

    public static void SetConnected(bool v)
    {
        print("Set Connected:" + v);
        INST.indiImage.sprite = v ? INST.OnSprite : INST.OffSprite;
       
      
    }

    // Start is called before the first frame update
    void Start()
    {
        INST = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(blink)
        {
            showBlink = !showBlink;
            blinkingText.SetActive(showBlink);
        }
    }

    internal static void StartBlinking()
    {
        if (INST == null)
            INST = FindObjectOfType<Indicator>();
        INST.blink = true;
        print("Start blinking");
    }

    internal static void StopBlinking()
    {
        INST.blink = false;
    }
}
