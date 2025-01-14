using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    // Start is called before the first frame update
    public MenuStateHandler mHandler;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        mHandler.SetState(new MenuCreditsState(mHandler));
    }

    public void BackButton()
    {
        mHandler.SetState(new MenuMainState(mHandler));
    }
}
