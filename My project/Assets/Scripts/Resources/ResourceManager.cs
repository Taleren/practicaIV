using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    //ES EL SUJETO DEL OBSERVER
    //public EventHandler<float>ResourceChanged;

    public static ResourceManager instance;
    public List<Resource> resources = new List<Resource>();

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

        if (resources.Count == 0)
        {
            // Inicializar los recursos por defecto (Beer, Cigarette, etc.)
            resources.Add(new Resource("Beer", 0));
            resources.Add(new Resource("Cigar", 0));
        }


    }

    

    public void AddResource(string resourceName, int amount)
    {
        Resource resource = resources.Find(r => r.resourceType == resourceName);
        if (resource!= null) //no estoy segura xd
        {
            Debug.Log($"Agregando {amount} al recurso: {resourceName}");
            resource.AddCount(amount);

            //Notificar a los observers
            OnResourceChanged?.Invoke(resourceName, resource.count);
        }

        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceName}");
        }


    }

    public void RemoveResource(string resourceName, int amount) 
    {
        Resource resource = resources.Find(r => r.resourceType == resourceName);
        if (resource != null)
        {
            Debug.Log($"Quitando {amount} del recurso: {resourceName}");
            resource.SubtractCount(amount);
            //Notificar a los observers
            OnResourceChanged?.Invoke(resourceName, resource.count);

        }
        else
        {
            Debug.LogWarning($"Recurso no encontrado: {resourceName}");
        }
    }

    public int GetResourceCount(string resourceName)
    {
        Resource resource = resources.Find(r => r.resourceType == resourceName);
        return resource!= null ? resource.count : 0;
    }
}
