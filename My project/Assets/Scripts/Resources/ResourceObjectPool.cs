using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialSize = 10; //Tamaño inicial del pool

    private Queue<GameObject> pool = new Queue<GameObject>();

    private void Awake()
    {
        //Inicialización del pool
        for (int i = 0; i<initialSize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public GameObject Get()
    {
        //Reutilizar si hay en el pool
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        //Si no hay disponibles en el pool, crea uno nuevo
        return Instantiate(prefab);
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(true);
        pool.Enqueue(obj);
    }
}
