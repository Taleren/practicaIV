using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BadguyEvent : IEvent
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
    public BadguyEvent(Platform p)
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

        bottomText.gameObject.SetActive(false);
        dialogueTextbox.text = "Vaquero, este camino procedural es demasiado pequeño para los dos. Aparta de mi camino o me llevaré todas esas preciosas cervezas que llevas";
        buttonATextbox.text = "Por encima de mi poligonal cadaver";
        buttonBTextbox.text = "Te daré un par de cigarros, pero déjame tranquilo";
        nameTextbox.text = "Jonnah Manodehierro";

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
                float random = Random.Range(0, .1f);
                if (random < platform.platformLoader.drunkCounter)
                {
                    bottomText.text = "Desafiaste a Manodehierro, pero ibas demasiado borracho";
                    AudioManager.instance.PlaySfxByIndex(8);
                    endEvent();
                    platform.platformLoader.AddBeer(Random.Range(-4, -2));
                    
                    break;
                }
                else
                {
                    bottomText.text = "Desafiaste a Manodehierro y lograste ahuyentarlo.";
                    AudioManager.instance.PlaySfxByIndex(8);
                    endEvent();
                    break;
                }
                
                
                
            case 1:
                //Debug.Log("atraco");
                bottomText.text = "Manodehierro acepta la oferta a regañadientes.";
                endEvent();
                platform.platformLoader.AddCigar(-2);
                //platform.platformLoader.SmokeCigar(1);
                break;
        }

    }
}
