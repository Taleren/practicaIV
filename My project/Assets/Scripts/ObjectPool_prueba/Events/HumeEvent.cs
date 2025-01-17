using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;

public class HumeEvent : IEvent
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
    public HumeEvent(Platform p)
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
        dialogueTextbox.text = "....*clank* *clank clonk*";
        buttonATextbox.text = "¡Coño! ¡Un fantasma!";
        buttonBTextbox.text = "Parece un tío legal.";
        nameTextbox.text = "El General Hume";

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
                AudioManager.instance.PlaySfxByIndex(8);
                bottomText.text = "Le disparaste al fantasma. Te fumas un cigarro y decides no volver a hablar de ello";
                endEvent();
                platform.platformLoader.SmokeCigar(1);
                
                break;
            case 1:
                bottomText.text = "Tú y el fantasma compartís una birra. Resulta ser una compañía estupenda";
                endEvent();
                platform.platformLoader.DrinkBeer(1);
                platform.platformLoader.AddBeer(-1);
                break;
        }

    }
}
