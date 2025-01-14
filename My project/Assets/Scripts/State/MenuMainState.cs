using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMainState : AMenuState
{
    // Start is called before the first frame update
    public MenuMainState(MenuStateHandler menu) : base(menu)
    {
    }

    public override void Enter()
    {
        mHandler.mainStateObject.SetActive(true);
    }
    public override void Exit()
    {
        mHandler.mainStateObject.SetActive(false);
    }
    public override void Update()
    {

    }
    //public abstract void FixedUpdate();



}
