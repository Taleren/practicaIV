using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class SheriffEvent : IEvent
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
    public SheriffEvent(Platform p)
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
        sprite = Resources.Load<Sprite>("Assets/UI/mike/");
        bottomText.gameObject.SetActive(false);
        dialogueTextbox.text = "¡Alto a la autoridad! Esto es un control rutinario. Le informo de que montar borracho es un delito federal";
        buttonATextbox.text = "";
        buttonBTextbox.text = "Pero si estoy perfectamente...";
        nameTextbox.text = "Sheriff J.Kisch";

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
                bottomText.text = "";
                //platform.platformLoader.SmokeCigar(1);
                endEvent();
                break;
            case 1:
                float random = Random.Range(0, .1f);
                if (random < platform.platformLoader.drunkCounter)
                {
                    bottomText.text = "El Sheriff no te detiene de milagro, pero te confisca unas cuantas cervezas";
                    endEvent();
                    platform.platformLoader.AddBeer(Random.Range(-6, -3));
                    
                    break;
                }
                else
                {
                    bottomText.text = "Pasas limpio por esta vez.";
                    endEvent();
                    break;
                }
        }

    }
}
