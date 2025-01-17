using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class MikeEvent : IEvent
{
    private Platform platform;
    private GameObject dialogueUI;
    private TMP_Text dialogueTextbox;
    private TMP_Text nameTextbox;
    private TMP_Text buttonATextbox;
    private TMP_Text buttonBTextbox;
    private Button buttonA;
    private Button buttonB;
    private TMP_Text bottomText;
    private Sprite sprite;
    public MikeEvent(Platform p)
    {
        platform = p;
    }

    public void startEvent()
    {
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
        sprite = Resources.Load<Sprite>("Assets/UI/mike/");
        bottomText.gameObject.SetActive(false);
        dialogueTextbox.text = "Es eso que huelo por ahí... ¿cigarros? ¿No le prestarías un chin de tabaco a un pobre compañero como yo? Creo que si no fumo ahora mismo podría volarme la cabeza  con el revolver...";
        buttonATextbox.text = "Aquí tienes";
        buttonBTextbox.text = "Ni hablar";
        nameTextbox.text = "Mike 'El Delicioso'";

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
                bottomText.text = "'El delicioso' parece muy contento y no deja de compararte con una cabra.";
                endEvent();
                platform.platformLoader.AddCigar(-1);
                
                break;
            case 1:
                bottomText.text = "Mike aprieta el gatillo con el revólver en la boca pero el mecanismo falla.  Necesitas una cerveza para superar esto. ";
                endEvent();
                platform.platformLoader.DrinkBeer(1);
                break;
        }

    }
}
