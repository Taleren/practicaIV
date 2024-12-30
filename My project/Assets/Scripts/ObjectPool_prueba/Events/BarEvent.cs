using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BarEvent : IEvent
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
    public BarEvent(Platform p)
    {
        platform = p;
    }

   
    public void startEvent()
    {
        //Debug.Log("-1 cerveza por puta");
        dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        dialogueUI.SetActive(true);
        platform.platformLoader.isPaused = true;
        dialogueTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[0];
        buttonATextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[1];
        buttonBTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[2];
        nameTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[3];
        buttonA = dialogueUI.GetComponentsInChildren<Button>()[0];
        buttonB = dialogueUI.GetComponentsInChildren<Button>()[1];
        buttonA.SetPlatformEvent(this);
        buttonB.SetPlatformEvent(this);

        dialogueTextbox.text = "es un bar esto";
        buttonATextbox.text = "dame cerveza";
        buttonBTextbox.text = "manos arriba";
        nameTextbox.text = "barman";

    }

    public void endEvent()
    {
        //dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        dialogueUI.SetActive(false);
        platform.platformLoader.isPaused = false;
    }

    public void HandleButton(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Debug.Log("cerveza");
                endEvent();
                break;
            case 1:
                Debug.Log("atraco");
                endEvent();
                break;
        }

    }
}
