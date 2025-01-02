using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public string resourceType; //Cerveza o cigarro
    public int count;           //Cantidad actual del recurso
    //public int maxCount;        //Cantidad máxima

    public Resource(string name, int initialCount)
    {
        resourceType = name;
        count = initialCount;
    }

    public delegate void ResourceUpdated();
    public event ResourceUpdated OnResourceUpdated;

    public void SetCount(int newCount)
    {
        count = newCount;
        OnResourceUpdated?.Invoke(); //Notificar de cabios
    }

    public void AddCount(int amount)
    {
        Debug.Log($"Cantidad actual del recurso {resourceType}: {count}");
        SetCount(count + amount);
    }

    public void SubtractCount(int amount)
    {
        SetCount(count - amount);
    }

    public int GetCount() => count; //Devuelve count
}
