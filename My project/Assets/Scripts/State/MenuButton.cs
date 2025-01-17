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
        AudioManager.instance.PlaySfxByIndex(2);
        Application.Quit();
    }

    public void PlayButton()
    {
        AudioManager.instance.PlaySfxByIndex(2);
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsButton()
    {
        AudioManager.instance.PlaySfxByIndex(2);
        mHandler.SetState(new MenuCreditsState(mHandler));
    }

    public void BackButton()
    {
        AudioManager.instance.PlaySfxByIndex(2);
        mHandler.SetState(new MenuMainState(mHandler));
    }
}
