using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ResourceUI : MonoBehaviour
{
    /*
    //observador
    public Resource resource;   //Recurso asociado
    public ResourceObjectPool objectPool;   //pool
    public Transform container; //Contenedor de los iconos

    /*

    private void Start()
    {
        if (resource!= null)
        {
            resource.OnResourceUpdated += UpdateUI;
            UpdateUI();
        }
    }

    private void OnDestroy()
    {
        if (resource!= null)
        {
            resource.OnResourceUpdated -= UpdateUI;
        }
    }

    public void UpdateUI()
    {
        //Limpiar el contenedor
        foreach (Transform child in container)
        {
            objectPool.Return(child.gameObject);
        }

        //Generar iconos como indique el count
        for (int i = 0; i<resource.GetCount(); i++)
        {
            GameObject icon = objectPool.Get();
            icon.transform.SetParent(container, false);
        }
    }*/
}
