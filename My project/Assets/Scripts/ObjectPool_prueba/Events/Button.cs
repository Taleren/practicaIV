using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    
    IEvent platformEvent;
    [SerializeField]int buttonID;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {
        platformEvent.HandleButton(buttonID);
    }

    public void SetPlatformEvent(IEvent p)
    {
        platformEvent = p;
    }
}
