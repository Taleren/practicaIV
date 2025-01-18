using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour, IObserver<ResourceQuantity>
{
    
    public void UpdateObserver(ResourceQuantity resource)
    {
        if (resource.quantity >= 0)
        {
            AddResource(resource.resourcetype, resource.quantity);
        }
        else
        {
            RemoveResource(resource.resourcetype, -resource.quantity);
        }
    }
    
    //Pools de cervezas y cigarros
    public ResourceObjectPool beerPool;
    public ResourceObjectPool cigarPool;


    private void Awake()
    {
        Object.FindObjectsOfType<PlatformLoader>()[0].AddObserver(this);

        cigarPool.AddCount(5);
        beerPool.AddCount(5);
    }

    

    public void AddResource(int resourceType, int amount)
    {

        if (resourceType == 0)
        {
            beerPool.AddCount(amount);
        }
        else if (resourceType == 1)
        {
            cigarPool.AddCount(amount);
        }

        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceType}");
        }
    }

    public void RemoveResource(int resourceType, int amount) 
    {
        if (resourceType == 0)
        {
            beerPool.SubtractCount(amount);
        }
        else if (resourceType == 1)
        {
            cigarPool.SubtractCount(amount);
        }

        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceType}");
        }
    }

    public int GetResourceCount(int resourceType)
    {
        int count = 0;  
        if (resourceType == 0)
        {
            count = beerPool.GetCount();
        }
        else if (resourceType == 1)
        {
            count = cigarPool.GetCount();
        }
        return count;
    }
}
