using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource :  MonoBehaviour, IPooleableObject
{
    public string resourceType; //Cerveza o cigarro
    //public int count;           //Cantidad actual del recurso
    //public int maxCount;      //Cantidad máxima

    public Resource(string name, int initialCount)
    {
        resourceType = name;
        //count = initialCount;
    }

    public delegate void ResourceUpdated();
    public event ResourceUpdated OnResourceUpdated;

    


    public bool Active
    {
        get
        {
            return gameObject.activeSelf;
        }

        set
        {
            gameObject.SetActive(value);
        }
    }

    public void Reset()
    {
        transform.localPosition = Vector3.zero;
    }
}
