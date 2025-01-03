
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Patterns.ObjectPool.UnityObjectPool;
//using Unity.Mathematics;
using UnityEngine;

public class Platform : MonoBehaviour, IPooleableObject
{
    [SerializeField] private string name;
    //[SerializeField] private Color32 colorTest;
    //[SerializeField] private string eventTest;
    [SerializeField] public PlatformLoader platformLoader;
    
    public GameObject canvas;

    public IEvent platformEvent;

    public bool isMoving;

    public int currentPosition;
    private int maxPlatformNumber;
    private Vector3 initialScale;
    private Color32 initialColor;
    private Color32 highlightedColor;
    private bool isClickable;
    public int branchPosition = -1;
    // Start is called before the first frame update

    void Awake()
    {
        initialScale = gameObject.transform.localScale;
        initialColor.a = highlightedColor.a = 255;
        initialColor.r = initialColor.g = initialColor.b = 138;
        highlightedColor.r = highlightedColor.b = highlightedColor.g = 180;
        maxPlatformNumber = platformLoader.maxPlatformNumber;


    }
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        isClickable = !isMoving && (currentPosition == 3) && !platformLoader.isPaused;
        /*
        if(currentPosition == 1)
        {
            //MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            //propertyBlock.SetFloat("_VanishFactor", .8f);
            //this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock);
        }
        */
    }

    public void Load(PlatformObject po)
    {
        name = po.name;
        //colorTest = po.colorTest;
        //eventTest = po.eventTest;
        //print("Plataforma cargada: " + name + "\n");
        //print("Evento iniciado: " + eventTest + "\n");
        //platformEvent = po.platformEvent;
        switch (po.platformEvent)
        {
            case PlatformObject.platformEventEnum.standard:
                platformEvent = new StandardEvent();
                break;
            case PlatformObject.platformEventEnum.testDialogue:
                platformEvent = new DialogueEvent(this);
                break;
            case PlatformObject.platformEventEnum.barDialogue:
                platformEvent = new BarEvent(this);
                break;
        }
        //MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        //propertyBlock.SetColor("_Color", colorTest);
        //this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock);


    }

    public void OnCreate(float s)
    {
        currentPosition = maxPlatformNumber;
        gameObject.transform.position += new Vector3(0f, -4f, 0f);
        StartCoroutine("GoIn", s);

        int random = Random.Range(0, 4);
        switch (random)
        {
            case 0:
                gameObject.transform.eulerAngles = new Vector3(-90f, 0f, 0f);
                break;
            case 1:
                gameObject.transform.eulerAngles = new Vector3(-90f, 90f, 0f);
                break;
            case 2:
                gameObject.transform.eulerAngles = new Vector3(-90f, 180f, 0f);
                break;
            case 3:
                gameObject.transform.eulerAngles = new Vector3(-90f, 270f, 0f);
                break;
        }
    }

    public void Move(float s)
    {
        if(currentPosition != 0)
        {
            currentPosition--;
            //this.transform.DOMoveX(gameObject.transform.position.x-1.7f, s);
            StartCoroutine("MoveForward", s);
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
        platformLoader.Release(this);
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

    IEnumerator MoveForward(float s)
    {

        isMoving = true;
        this.transform.DOMoveX(gameObject.transform.position.x-1.7f, s);
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


    
    private void OnMouseExit()
    {
        gameObject.transform.localScale = initialScale;
        MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
        propertyBlock.SetColor("_Color", initialColor);
        this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock);
    }

    private void OnMouseOver()
    {
        if (isClickable)
        {
            gameObject.transform.localScale = initialScale + new Vector3(.2f, .2f, .2f);
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            propertyBlock.SetColor("_Color", highlightedColor);
            this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock);
            if (Input.GetMouseButtonDown(0))
            {
                switch(branchPosition)
                {
                    case -1:
                        platformLoader.createRandomPlatform();
                        gameObject.transform.localScale = initialScale;
                        MaterialPropertyBlock propertyBlock2 = new MaterialPropertyBlock();
                        propertyBlock2.SetColor("_Color", initialColor);
                        platformEvent.startEvent();
                        this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock2);
                        break;
                    case 0:
                        platformLoader.chooseBranch(0);
                        MaterialPropertyBlock propertyBlock3 = new MaterialPropertyBlock();
                        propertyBlock3.SetColor("_Color", initialColor);
                        this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock3);
                        break;
                    case 1:
                        platformLoader.chooseBranch(1);
                        MaterialPropertyBlock propertyBlock4 = new MaterialPropertyBlock();
                        propertyBlock4.SetColor("_Color", initialColor);
                        this.GetComponentInChildren<MeshRenderer>().SetPropertyBlock(propertyBlock4);
                        break;
                }
                
            }
        }

    }

    public void MoveLeft()
    {
        if(branchPosition == 0)
        {
            branchPosition = -1;
            StartCoroutine("Center");
        }
        else if (branchPosition == 1)
        {
            branchPosition = -1;
            StartCoroutine("VanishLeft");
        }
        
    }

    public void MoveRight()
    {
        if (branchPosition == 0)
        {
            branchPosition = -1;
            StartCoroutine("VanishRight");
        }
        else if (branchPosition == 1)
        {
            branchPosition = -1;
            StartCoroutine("Center");
        }
    }

    private IEnumerator Center()
    {
        isMoving = true;
        this.transform.DOMoveZ(0, .4f);
        yield return new WaitForSeconds(.4f);
        //Destroy(gameObject);
        //platformLoader.Release(this);
        isMoving = false;
    }

    private IEnumerator VanishLeft()
    {
        isMoving = true;
        this.transform.DOMove(new Vector3(this.transform.position.x, -4f, -2f), .4f);
        yield return new WaitForSeconds(.4f);
        //Destroy(gameObject);
        platformLoader.Release(this);
        isMoving = false;
    }

    private IEnumerator VanishRight()
    {
        isMoving = true;
        this.transform.DOMove(new Vector3(this.transform.position.x, -4f, 2f), .4f);
        yield return new WaitForSeconds(.4f);
        //Destroy(gameObject);
        platformLoader.Release(this);
        isMoving = false;
    }

}
