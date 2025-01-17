using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueEvent : IEvent
{
    public Platform platform;
    private GameObject dialogueUI;
    private TMP_Text dialogueTextbox;
    private TMP_Text nameTextbox;
    private TMP_Text buttonATextbox;
    private TMP_Text buttonBTextbox;
    private Button buttonA;
    private Button buttonB;
    public DialogueEvent(Platform p)
    {
        platform = p;
        
    }

    public DialogueEvent()
    {
        platform = null;
    }
    public void startEvent()
    {

        dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        dialogueUI.SetActive(true);
        platform.isMoving = true;
        dialogueTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[0];
        buttonATextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[1];
        buttonBTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[2];
        nameTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[3];
        buttonA = dialogueUI.GetComponentsInChildren<Button>()[0];
        buttonB = dialogueUI.GetComponentsInChildren<Button>()[1];
        buttonA.SetPlatformEvent(this);
        buttonB.SetPlatformEvent(this);

        dialogueTextbox.text = "nicky nicole si o no";
        buttonATextbox.text = "si";
        buttonBTextbox.text = "no";
        nameTextbox.text = "nicky nicole";

    }

    public void endEvent()
    {
        //dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        dialogueUI.SetActive(false);
        platform.isMoving = false;
    }

    public void HandleButton(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                Debug.Log("nickyNicole si");
                endEvent();
                break;
            case 1:
                Debug.Log("nickyNicole no");
                endEvent();
                break;
        }

    }
}
