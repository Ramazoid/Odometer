using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sounds : MonoBehaviour
{
    private AudioSource[] players;
    private AudioSource SoundPlayer;
    private bool SoundIsPlaying;
    private AudioSource FxPlayer;
    public Image SoundIcon;
    public Slider SoundSlider;

    void Start()
    {
        players=GetComponents<AudioSource>();
        SoundPlayer = players[0];
        SoundPlayer.Play(); SoundIsPlaying = true;UpdateIcon(SoundIcon, SoundIsPlaying);
        FxPlayer = players[1];
    }

    private void UpdateIcon(Image icon, bool IsPlaying)
    {
        icon.color = IsPlaying? Color.black : Color.gray;
    }
    public void SoundValue()
    {
        SoundPlayer.volume = SoundSlider.value;
    }

    public void SoundONOff()
    {
        SoundIsPlaying = !SoundIsPlaying;
        if (SoundIsPlaying)
            SoundPlayer.Play();
        else
            SoundPlayer.Stop();
        ; UpdateIcon(SoundIcon, SoundIsPlaying);
    }
    
    void Update()
    {
        
    }
}
