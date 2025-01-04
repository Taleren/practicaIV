using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{


    public static ResourceManager instance;
    //public List<Resource> resources = new List<Resource>();

    public ResourceObjectPool beerPool;
    public ResourceObjectPool cigarPool;

    //Delegado y evento para observer
    public delegate void ResourceChanged(string resourceType, int newAmount);
    public event ResourceChanged OnResourceChanged;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance !=this)
        {
            Destroy(gameObject);
        }

        cigarPool.AddCount(5);
        //AddResource("Beer", 5);

        Debug.Log(cigarPool.GetCount());

        beerPool.AddCount(5);
        
        Debug.Log(beerPool.GetCount());

    }

    

    public void AddResource(string resourceName, int amount)
    {

        if (resourceName == "Beer")
        {
            beerPool.AddCount(amount);
            Debug.Log($"Agregando {amount} al recurso: {resourceName}");
        }
        else if (resourceName == "Cigar")
        {
            cigarPool.AddCount(amount);
            Debug.Log($"Agregando {amount} al recurso: {resourceName}");
        }

        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceName}");
        }
    }

    public void RemoveResource(string resourceName, int amount) 
    {
        if (resourceName == "Beer")
        {
            beerPool.SubtractCount(amount);
            Debug.Log($"Quitando {amount} al recurso: {resourceName}");
        }
        if (resourceName == "Cigar")
        {
            cigarPool.SubtractCount(amount);
            Debug.Log($"Quitando {amount} al recurso: {resourceName}");
        }

        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceName}");
        }
    }

    public int GetResourceCount(string resourceName)
    {
        int count = 0;  
        if (resourceName == "Beer")
        {
            count = beerPool.GetCount();
        }
        if (resourceName == "Cigar")
        {
            count = cigarPool.GetCount();
        }
        return count;
    }
}
