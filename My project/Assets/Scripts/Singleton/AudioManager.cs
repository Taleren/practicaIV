using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //2 fuentes de audio de música y 1 de fx

    private AudioSource as_sfx;
    private AudioSource[] as_music;

    //Lista de audioclips
    public List<AudioClip> clipList;
    public List<AudioClip> sfxList;



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
    public void PlayMusic(int musicIndex, AudioClip clip, bool loop = true)
    {
        if (musicIndex >= 0 && musicIndex < as_music.Length && as_music[musicIndex] != null)
        {
            as_music[musicIndex].clip = clip; //Auidioclip al audiosource
            as_music[musicIndex].loop = loop; //Repe
            as_music[musicIndex].Play();
        }
        else
        {
            Debug.LogWarning($"El índice {musicIndex} está fuera de rango o el AudioSource no está asignado.");
        }
    }

    //Stop Music
    public void StopMusic(int musicIndex)
    {
        if (musicIndex >= 0 && musicIndex < as_music.Length && as_music[musicIndex] != null)
        {
            as_music[musicIndex].Stop();
        }
        else
        {
            Debug.LogWarning($"El índice {musicIndex} está fuera de rango o el AudioSource no está asignado.");
        }
    }

    public void PlayMusicByIndex(int index,int musicIndex)
    {
        if (musicIndex >= 0 && musicIndex < clipList.Count)
        {
            PlayMusic(index, clipList[musicIndex]);
        }
        else
        {
            Debug.LogWarning($"El índice {musicIndex} está fuera de rango.");
        }
    }

    public void StopMusicByIndex(int index, int musicIndex)
    {
        if (musicIndex >= 0 && musicIndex < clipList.Count)
        {
            StopMusic(musicIndex);
        }
        else
        {
            Debug.LogWarning($"El índice {musicIndex} está fuera de rango.");
        }
    }

    public void PlaySfxByIndex(int sfxIndex)
    {
        if (sfxIndex >= 0 && sfxIndex < sfxList.Count)
        {
            PlaySFX(sfxList[sfxIndex]);
        }
        else
        {
            Debug.LogWarning($"El índice {sfxIndex} está fuera de rango.");
        }
    }

}
