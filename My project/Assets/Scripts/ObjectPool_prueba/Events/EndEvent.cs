using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndEvent : IEvent
{
    //public Platform platform;
    private Platform platform;
    private GameObject dialogueUI;
    private TMP_Text dialogueTextbox;
    private TMP_Text nameTextbox;
    private TMP_Text buttonATextbox;
    private TMP_Text buttonBTextbox;
    private Button buttonA;
    private Button buttonB;
    private TMP_Text bottomText;
    public EndEvent(Platform p)
    {
        platform = p;
    }

   
    public void startEvent()
    {
        platform.platformLoader.EndGame(true);
    }

    public void endEvent()
    {
        
    }

    public void HandleButton(int buttonID)
    {
        
        

    }
}
