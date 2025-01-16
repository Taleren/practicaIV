using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTest : MonoBehaviour
{
    public AudioClip sfxClip;       // Efecto de sonido
    public AudioClip musicClip0;    // Música de fondo
    public AudioClip musicClip1;    // Música de fondo

    void Start()
    {
        // Reproducir un efecto de sonido
        //AudioManager.instance.PlaySFX(sfxClip);

        // Reproducir música en el canal 0
        //AudioManager.instance.PlayMusic(0, musicClip0, true);

        // Reproducir música en el canal 1
        //AudioManager.instance.PlayMusic(1, musicClip1, true);
    }

    void Update()
    {
        // Presiona "S" para detener la música del canal 0
        if (Input.GetKeyDown(KeyCode.W))
        {
            AudioManager.instance.PlayMusic(0, musicClip0, true);
        }

        // Presiona "M" para reproducir nuevamente la música
        if (Input.GetKeyDown(KeyCode.S))
        {
            AudioManager.instance.PlayMusic(1, musicClip1, true);
        }
    }
}
