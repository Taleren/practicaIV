using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int poolInitialSize = 10; //Tamaño inicial del pool
    int activeResources = 0;

    private List<IPooleableObject> resourcePool = new List<IPooleableObject>();
    private Stack<IPooleableObject> resourceStack = new Stack<IPooleableObject>();

    private void Awake()
    {
        //Inicialización del pool
        for (int i = 0; i<poolInitialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            IPooleableObject resource = obj.GetComponent<IPooleableObject>();
            resource.Active = false;
            resourcePool.Add(resource);   //Meter en el stack uno
        }
    }


    public IPooleableObject Get()
    {
        for (int i = 0; i < resourcePool.Count; i++)
        {
            if (!resourcePool[i].Active)
            {
                resourcePool[i].Active = true;
                activeResources++;
                return resourcePool[i];
            }
        }

        return null;
    }

    public void Release(IPooleableObject obj)
    {
        obj.Active = false;
        activeResources--;
        obj.Reset();
    }

    /*
    public void Return(GameObject obj)
    {
        obj.SetActive(true);
        pool.Enqueue(obj);
    }*/


    public void AddCount(int amount)
    {
        for(int i = 0; i<amount; i++)
        {
            resourceStack.Push(Get());
            Debug.Log("Recurso añadido al stack");
        }
    }

    public void SubtractCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if(resourceStack.Count > amount)
            {
                resourceStack.Pop(); 
                Debug.Log("Recurso quitado del stack");
            }

            else
            {
                resourceStack.Clear();
                Debug.Log("Stack Vaciado");
            }

        }
    }

    public int GetCount() => activeResources; //Devuelve count
}
