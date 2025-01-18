using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleObserver : MonoBehaviour, IObserver<ResourceQuantity>
{
    // Start is called before the first frame update
    void Start()
    {
        Object.FindObjectsOfType<PlatformLoader>()[0].AddObserver(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateObserver(ResourceQuantity resource)
    {
        if(resource.resourcetype == 0)
        {
            if(resource.quantity < 0)
            {
                ParticleManager.instance.PlayParticle(1);
            }
           
        }
        if (resource.resourcetype == 1)
        {
            if (resource.quantity < 0)
            {
                
                ParticleManager.instance.PlayParticle(0);
            }

        }
    }
}
