using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //2 fuentes de audio de música y 1 de fx

    private AudioSource as_sfx;
    private AudioSource[] as_music;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject); //Si ya existe una instancia
        }
        DontDestroyOnLoad(gameObject);

        //Inicialización
        as_sfx = transform.Find("AS_SFX").GetComponent<AudioSource>();
        as_music = new AudioSource[2];
        for (int i = 0; i < as_music.Length; i++)
        {
            as_music[i] = transform.Find("AS_Music_" + i.ToString()).GetComponent<AudioSource>();
        }
    }

    //Play SFX
    public void PlaySFX(AudioClip clip)
    {
        if(as_sfx!= null)
        {
            as_sfx.PlayOneShot(clip);
        }

        else
        {
            Debug.Log("AS_SFX no asignado");
        }
    }

    //Play Music
    public void PlayMusic(int index, AudioClip clip, bool loop = true)
    {
        if (index >= 0 && index < as_music.Length && as_music[index] != null)
        {
            as_music[index].clip = clip; //Auidioclip al audiosource
            as_music[index].loop = loop; //Repe
            as_music[index].Play();
        }
        else
        {
            Debug.LogWarning($"El índice {index} está fuera de rango o el AudioSource no está asignado.");
        }
    }

    //Stop Music
    public void StopMusic(int index)
    {
        if (index >= 0 && index < as_music.Length && as_music[index] != null)
        {
            as_music[index].Stop();
        }
        else
        {
            Debug.LogWarning($"El índice {index} está fuera de rango o el AudioSource no está asignado.");
        }
    }

}
