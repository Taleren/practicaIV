using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCreditsState : AMenuState
{
    // Start is called before the first frame update
    public MenuCreditsState(MenuStateHandler menu) : base(menu)
    {
    }

    public override void Enter()
    {
        mHandler.creditsStateObject.SetActive(true);
    }
    public override void Exit()
    {
        mHandler.creditsStateObject.SetActive(false);
    }
    public override void Update()
    {

    }
    //public abstract void FixedUpdate();



}
