using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SmokeEvent : IEvent
{
    //public Platform platform;
    private Platform platform;
    private GameObject dialogueUI;
    private TMP_Text dialogueTextbox;
    private TMP_Text nameTextbox;
    private TMP_Text buttonATextbox;
    private TMP_Text bottomText;
    private TMP_Text buttonBTextbox;
    private Button buttonA;
    private Button buttonB;
    public SmokeEvent(Platform p)
    {
        platform = p;
    }

   
    public void startEvent()
    {
        AudioManager.instance.PlayMusicByIndex(0, 2);
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
        dialogueTextbox.text = "Hola, forastero... El gran oráculo me narra tu futuro, y en él hay un cigarro de la mejor calidad.\nEcha un vistazo, siempre llevo el mejor género, apenas lleva plomo";
        buttonATextbox.text = "";
        buttonBTextbox.text = "Me vendría bien un paquete";
        nameTextbox.text = "Lluvia Repentina";

    }

    public void endEvent()
    {
        AudioManager.instance.PlayMusicByIndex(0, 0);
        //dialogueUI = platform.canvas.transform.GetChild(0).gameObject;
        foreach (Transform g in dialogueUI.GetComponentsInChildren<Transform>())
        {
            g.gameObject.SetActive(false);
        }
        //dialogueUI.SetActive(false);
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
                endEvent();
                break;
            case 1:
                bottomText.text = "Lluvia Repentina compartió su tabaco contigo.";
                platform.platformLoader.AddCigar(5);
                //Debug.Log("atraco");
                endEvent();
                break;
        }

    }
}
