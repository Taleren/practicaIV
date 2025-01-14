using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AMenuState : IState
{
    // Start is called before the first frame update
    protected MenuStateHandler mHandler;
    
    public AMenuState(MenuStateHandler handler)
    {
        this.mHandler = handler;
    }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    //public abstract void FixedUpdate();



}
