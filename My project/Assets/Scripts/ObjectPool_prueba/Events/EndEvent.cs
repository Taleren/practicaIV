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
        //Debug.Log("-1 cerveza por puta");
        dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        dialogueUI.SetActive(true);
        foreach (Transform g in dialogueUI.GetComponentsInChildren<Transform>(true))
        {
            g.gameObject.SetActive(true);
        }
        platform.platformLoader.isPaused = true;
        dialogueTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[0];
        buttonATextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[1];
        buttonBTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[2];
        nameTextbox = dialogueUI.GetComponentsInChildren<TMP_Text>()[3];
        bottomText = dialogueUI.GetComponentsInChildren<TMP_Text>()[4];
        buttonA = dialogueUI.GetComponentsInChildren<Button>()[0];
        buttonB = dialogueUI.GetComponentsInChildren<Button>()[1];
        buttonA.SetPlatformEvent(this);
        buttonB.SetPlatformEvent(this);

        bottomText.gameObject.SetActive(false);
        dialogueTextbox.text = "es un bar esto";
        buttonATextbox.text = "dame cerveza";
        buttonBTextbox.text = "manos arriba";
        nameTextbox.text = "barman";

    }

    public void endEvent()
    {
        //dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        foreach (Transform g in dialogueUI.GetComponentsInChildren<Transform>())
        {
            g.gameObject.SetActive(false);
        }
        dialogueUI.SetActive(true);
        bottomText.gameObject.SetActive(true);
        bottomText.gameObject.GetComponent<Animator>().Play("fade");
        platform.platformLoader.isPaused = false;
    }

    public void HandleButton(int buttonID)
    {
        switch (buttonID)
        {
            case 0:
                //Debug.Log("cerveza");
                bottomText.text = "cervezo";
                platform.platformLoader.AddBeer(Random.Range(3,6));
                endEvent();
                break;
            case 1:
                //Debug.Log("atraco");
                bottomText.text = "atraco";
                endEvent();
                platform.platformLoader.AddBeer(Random.Range(6, 10));
                platform.platformLoader.SmokeCigar(1);
                break;
        }

    }
}
