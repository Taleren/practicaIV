using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MenuStateHandler : MonoBehaviour
{
    private IState currentState;
    public GameObject mainStateObject;
    public GameObject creditsStateObject;

    // Start is called before the first frame update
    void Start()
    {
        mainStateObject.SetActive(false);
        creditsStateObject.SetActive(false);
        SetState(new MenuMainState(this));
    }

    // Update is called once per frame
    void Update()
    {
        currentState.Update();
    }

    public void SetState(IState state)
    {
        // Exit old state
        if (currentState != null)
        {
            currentState.Exit();
        }

        // Set current state and enter
        currentState = state;
        currentState.Enter();
    }


}
