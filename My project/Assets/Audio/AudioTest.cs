using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip sfxClip;       // Efecto de sonido
    public AudioClip musicClip0;    // M�sica de fondo
    public AudioClip musicClip1;    // M�sica de fondo

    void Start()
    {
        // Reproducir un efecto de sonido
        //AudioManager.instance.PlaySFX(sfxClip);

        // Reproducir m�sica en el canal 0
        //AudioManager.instance.PlayMusic(0, musicClip0, true);

        // Reproducir m�sica en el canal 1
        //AudioManager.instance.PlayMusic(1, musicClip1, true);
    }

    void Update()
    {
        // Presiona "S" para detener la m�sica del canal 0
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlayMusic(0, musicClip0, true);
        }

        // Presiona "M" para reproducir nuevamente la m�sica
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.PlayMusic(1, musicClip1, true);
        }
    }
}
