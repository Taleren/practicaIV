using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEvent : IEvent
{
    Platform platform;
    public StandardEvent(Platform p)
    {
        platform = p;
    }

    public void startEvent()
    {
        platform.platformLoader.DrinkBeer(1);
    }

    public void endEvent()
    {
        
    }

    public void HandleButton(int b)
    {

    }
}
