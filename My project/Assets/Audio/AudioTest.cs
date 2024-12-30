using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip sfxClip;       // Efecto de sonido
    public AudioClip musicClip;    // Música de fondo

    void Start()
    {
        // Reproducir un efecto de sonido
        AudioManager.instance.PlaySFX(sfxClip);

        // Reproducir música en el canal 0
        AudioManager.instance.PlayMusic(0, musicClip, true);
    }

    void Update()
    {
        // Presiona "S" para detener la música del canal 0
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.StopMusic(0);
        }

        // Presiona "M" para reproducir nuevamente la música
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioManager.instance.PlayMusic(0, musicClip);
        }
    }
}
