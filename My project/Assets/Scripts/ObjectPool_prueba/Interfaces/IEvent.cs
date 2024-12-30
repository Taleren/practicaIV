using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface IEvent
{
    //public Platform platform;
    public void startEvent();
    public void endEvent();

    public void HandleButton(int buttonId);

}
