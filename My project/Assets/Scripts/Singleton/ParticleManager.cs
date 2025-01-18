using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager instance;

    /*
    private ParticleSystem smoke;
    private ParticleSystem drink;
    private ParticleSystem dust;
    private ParticleSystem jump;
    */

    //Lista de audioclips
    public List<ParticleSystem> particles;



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
        /*
        smoke = gameObject.GetComponentsInChildren<ParticleSystem>()[0];
        jump = gameObject.GetComponentsInChildren<ParticleSystem>()[1];
        drink = gameObject.GetComponentsInChildren<ParticleSystem>()[2];
        dust = gameObject.GetComponentsInChildren<ParticleSystem>()[3];
        */
    }

    //Play particle
    public void PlayParticle(int index)
    {
        particles[index].gameObject.SetActive(true);
        particles[index].Play();
    }
    

}
