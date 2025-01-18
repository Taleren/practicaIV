using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public GameObject container;

    public int poolInitialSize = 3;
    int activeResources = 0;
    
    private List<IPooleableObject> resourcePool = new List<IPooleableObject>();
    private Stack<IPooleableObject> resourceStack = new Stack<IPooleableObject>();

    

    private void Awake()
    {
        //Inicialización del pool
        for (int i = 0; i<poolInitialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(container.transform, false);

            IPooleableObject resource = obj.GetComponent<IPooleableObject>();
            resource.Active = false;
            
            resourcePool.Add(resource);   
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

    public void AddCount(int amount)
    {
        for(int i = 0; i<amount; i++)
        {
            Resource r = (Resource)Get();
            resourceStack.Push(r);
            activeResources++;
        }
    }

    public void SubtractCount(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            if(resourceStack.Count >= amount)
            {
                IPooleableObject resource = resourceStack.Pop();
                Release(resource);
                activeResources--;
            }

            //Vaciar el stack
            else
            {
                activeResources = 0;
                resourceStack.Clear();
            }

        }
    }

    public int GetCount() => activeResources;
}
