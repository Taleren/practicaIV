using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource :  MonoBehaviour, IPooleableObject
{
    public string resourceType; //Cerveza o cigarro



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
