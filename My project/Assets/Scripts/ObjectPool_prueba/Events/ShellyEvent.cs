using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
public class ShellyEvent : IEvent
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
    private Image image;
    public ShellyEvent(Platform p)
    {
        platform = p;
    }

    public void startEvent()
    {
        dialogueUI = platform.canvas.transform.GetChild(1).gameObject;
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
        image = dialogueUI.GetComponentsInChildren<Image>()[5];
        buttonA.SetPlatformEvent(this);
        buttonB.SetPlatformEvent(this);
        sprite = Resources.Load<Sprite>("UI/shelly");
        image.sprite = sprite;
        bottomText.gameObject.SetActive(false);
        dialogueTextbox.text = "¿Qué te cuentas forastero? Menudas pintas llevas... A cambio de un trago podría darte una lección o dos sobre la moda actual. Hasta tu caballo parece más elegante que tú.";
        buttonATextbox.text = "Cuéntame lo que sepas";
        buttonBTextbox.text = "El Largo no tiene ni idea";
        nameTextbox.text = "Shelly 'El Largo'";

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
                bottomText.text = "A cambio de una cerveza, el Largo te da una aburrida charla sobre chalecos";
                endEvent();
                platform.platformLoader.AddBeer(-1);
                
                break;
            case 1:
                bottomText.text = "¿O sí? ¿Acaso sabes algo de moda? Sus palabras te han hecho daño pero no hay nada que un cigarro no solucione";
                endEvent();
                platform.platformLoader.SmokeCigar(1);
                break;
        }

    }
}
