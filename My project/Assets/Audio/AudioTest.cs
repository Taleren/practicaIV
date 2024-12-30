using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip sfxClip;       // Efecto de sonido
    public AudioClip musicClip;    // M�sica de fondo

    void Start()
    {
        // Reproducir un efecto de sonido
        AudioManager.instance.PlaySFX(sfxClip);

        // Reproducir m�sica en el canal 0
        AudioManager.instance.PlayMusic(0, musicClip, true);
    }

    void Update()
    {
        // Presiona "S" para detener la m�sica del canal 0
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.StopMusic(0);
        }

        // Presiona "M" para reproducir nuevamente la m�sica
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.instance.PlayMusic(0, musicClip);
        }
    }
}
