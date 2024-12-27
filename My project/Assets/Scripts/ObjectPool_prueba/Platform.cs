using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Patterns.ObjectPool.UnityObjectPool;
using UnityEngine;

public class Platform : MonoBehaviour, IPooleableObject
{
    [SerializeField] private string name;
    [SerializeField] private Color32 colorTest;
    [SerializeField] private string eventTest;

    public bool isMoving;
    public int currentPosition;
    private int maxPlatformNumber = 4;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load(PlatformObject po)
    {
        name = po.name;
        colorTest = po.colorTest;
        eventTest = po.eventTest;
        print("Plataforma cargada: " + name + "\n");
        print("Evento iniciado: " + eventTest + "\n");

        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", colorTest);
        this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock);

    }

    public void OnCreate(float s)
    {
        currentPosition = maxPlatformNumber;
        gameObject.transform.position += new Vector3(0f, -4f, 0f);
        StartCoroutine("GoIn", s);
    }

    public void Move(float s)
    {
        if(currentPosition != 0)
        {
            currentPosition--;
            this.transform.DOMoveX(gameObject.transform.position.x-1.7f, s);
        }
        else if (currentPosition == 0)
        {
            //Debug.Log("Destruir en 0");
            //this.transform.DOMoveY(- 4f, 1);
            //yield return new WaitForSeconds(1);
            //Destroy(gameObject);
            StartCoroutine("GoOut", s);
        }
        
    }

    IEnumerator GoOut(float s)
    {
        isMoving = true;
        this.transform.DOMoveY(-4f, s);
        yield return new WaitForSeconds(s);
        //Destroy(gameObject);
        PlatformLoader.Instance.Release(this);
        isMoving = false;
    }

    IEnumerator GoIn(float s)
    {

        isMoving = true;
        this.transform.DOMoveY(0, s);
        yield return new WaitForSeconds(s);
        //Destroy(gameObject);
        isMoving = false;
    }

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
        // Debug.Log($"New SnowFlake initialized at: {transform.position}");
    }

    public Platform Clone(GameObject parent)
    {
        
        GameObject newObject = Instantiate(gameObject, parent.GetComponent<Transform>());
        Platform platform = newObject.GetComponent<Platform>();
        return platform;
    }
}
