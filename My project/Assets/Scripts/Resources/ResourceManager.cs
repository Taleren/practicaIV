using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour, IObserver<ResourceQuantity>
{
    //OBSERVER:
    
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



    public ResourceObjectPool beerPool;
    public ResourceObjectPool cigarPool;

    //Delegado y evento para observer
    public delegate void ResourceChanged(string resourceType, int newAmount);
    public event ResourceChanged OnResourceChanged;

    private void Awake()
    {
        Object.FindObjectsOfType<PlatformLoader>()[0].AddObserver(this);

        cigarPool.AddCount(5);
        //AddResource("Beer", 5);

        Debug.Log(cigarPool.GetCount());

        beerPool.AddCount(5);
        
        Debug.Log(beerPool.GetCount());

    }

    

    public void AddResource(int resourceType, int amount)
    {

        if (resourceType == 0)
        {
            beerPool.AddCount(amount);
            Debug.Log($"Agregando {amount} al recurso: {resourceType}");
        }
        else if (resourceType == 1)
        {
            cigarPool.AddCount(amount);
            Debug.Log($"Agregando {amount} al recurso: {resourceType}");
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
            Debug.Log($"Quitando {amount} al recurso: {resourceType}");
        }
        else if (resourceType == 1)
        {
            cigarPool.SubtractCount(amount);
            Debug.Log($"Quitando {amount} al recurso: {resourceType}");
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
