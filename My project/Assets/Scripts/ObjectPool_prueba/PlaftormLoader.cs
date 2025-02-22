using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformLoader : MonoBehaviour, IObjectPool, ISubject<ResourceQuantity>
{
    //public static PlatformLoader Instance;

    [SerializeField] private List<PlatformObject> platformObjects;
    [SerializeField] private PlatformObject endPlatform;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platformParent;
    [SerializeField] private float branchProbability;
    [SerializeField] private Material fullscreenMat;
    [SerializeField] private GameObject endGame;

    public int beerInitialCount;
    public int cigarInitialCount;
    private int beerCount;
    private int cigarCount;
    private int totalBeer=0;
    private int totalCigar=0;
    public float drunkCounter = 0;

    public GameObject player;
    Animator playerAnim;
    public int pathCounter;
    public int maxPathCounter;

    private float currentBranchProbability;
    public bool isPaused = false;
    bool isEnded = false;
    private List<Platform> poolablePlatforms = new List<Platform>(); 
    int activePlatforms = 0;
    int totalPoolSize = 12;
    [SerializeField] int usedSlots = 0;

    bool isBranch = false;

    [SerializeField] private float platformMoveSpeed;

    public int maxPlatformNumber = 4;
    private Queue<Platform> platformList = new Queue<Platform>();
    private Queue<Platform> leftBranchQueue = new Queue<Platform>();
    private Queue<Platform> rightBranchQueue = new Queue<Platform>();


    Vector3 lastPlatformPos = new Vector3(6.0999999f,-4f, -0.14738825f);

    int probabilityTotal;

    bool canClick;

    float distortion = 0;

    private List<IObserver<ResourceQuantity>> observerList = new List<IObserver<ResourceQuantity>>();

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ParticleManager.instance.PlayParticle(2);
        AudioManager.instance.PlayMusicByIndex(0, 0);
        AddCigar(cigarInitialCount);
        AddBeer(beerInitialCount);
        cigarCount = cigarInitialCount;
        beerCount = beerInitialCount;
        fullscreenMat.SetFloat("_distortionBlend", distortion);
        currentBranchProbability = branchProbability;
        poolablePlatforms.Add(platformPrefab.GetComponent<Platform>());
        platformPrefab.GetComponent<Platform>().Active = false;
        playerAnim = player.GetComponent<Animator>();


        for (int i = 0; i < totalPoolSize-1; i++)
        {
            poolablePlatforms.Add(platformPrefab.GetComponent<Platform>().Clone(platformParent));
            poolablePlatforms[i].Active = false;
        }
        //createPlatform();
        probabilityTotal = 0;
        foreach (PlatformObject p in platformObjects)
        {
            probabilityTotal += p.appearRatio;
        }

        
           
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            createRandomPlatform();


        }
        if (activePlatforms < maxPlatformNumber && pathCounter < maxPathCounter)
        {
            //canClick = false;
            createPlatform(platformObjects[0], platformMoveSpeed/2);
            
        }else
        {
            //canClick = true;
        }
        if(isEnded && Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene("Menu");
        }
       
    }

    private void createPlatform(PlatformObject p, float s)
    {
        bool aPlatformIsMoving = false;
        foreach (Platform pf in platformList)
        {
            aPlatformIsMoving = pf.isMoving;
        }
        //while(aPlatformIsMoving);
        if (!aPlatformIsMoving && !isPaused)
        {
            Platform platform = (Platform)Get();


            if (platformList.Count != 0 )
            {

                foreach (Platform pf in platformList)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
                foreach (Platform pf in rightBranchQueue)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
                foreach (Platform pf in leftBranchQueue)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
            }

            if (usedSlots == maxPlatformNumber)
            {

                platformList.Dequeue().Move(s);
                usedSlots--;
            }


            usedSlots++;
            platform.Load(p);
            platform.gameObject.transform.position = new Vector3(6.06f, -4, 0);
            platform.OnCreate(s);
            platformList.Enqueue(platform);

        }
    }

        public IPooleableObject Get()
        {
            for (int i = 0; i < poolablePlatforms.Count; i++)
            {
                if (!poolablePlatforms[i].Active)
                {
                    poolablePlatforms[i].Active = true;
                    activePlatforms += 1;
                    return poolablePlatforms[i];
                }
            }

            return null;
    }

    public void Release(IPooleableObject obj)
    {
        obj.Active = false;
        activePlatforms -= 1;
        obj.Reset();
    }

    public void createRandomPlatform()
    {
        //distortion += 0.01f;
        //fullscreenMat.SetFloat("_distortionBlend", distortion);
        if (pathCounter < maxPathCounter)
        {
            pathCounter++;
            playerAnim.Play("PlayerMove");
            ParticleManager.instance.PlayParticle(3);
            AudioManager.instance.PlaySfxByIndex(0); 
            int isBranched = Random.Range(0, 100);
            if (isBranched > branchProbability && !isBranch)
            {
                int random = Random.Range(0, probabilityTotal);
                int i = 0;
                while (i < platformObjects.Count - 1 && random > platformObjects[i].appearRatio)
                {

                    random -= platformObjects[i].appearRatio;
                    i++;
                }
                //Mathf.Clamp(i, 1, platformObjects.Count);
                createPlatform(platformObjects[i], platformMoveSpeed);

            }
            else
            {
                int random1 = Random.Range(0, probabilityTotal);
                int i = 0;
                while (i < platformObjects.Count - 1 && random1 > platformObjects[i].appearRatio)
                {

                    random1 -= platformObjects[i].appearRatio;
                    i++;
                }
                int random2 = Random.Range(0, probabilityTotal);
                int j = 0;
                while (j < platformObjects.Count - 1 && random2 > platformObjects[i].appearRatio)
                {

                    random2 -= platformObjects[j].appearRatio;
                    j++;
                }
                //Mathf.Clamp(j, 1, platformObjects.Count);
                //Mathf.Clamp(i, 1, platformObjects.Count);
                createBranchPlatform(platformObjects[j], platformObjects[i], platformMoveSpeed);
                isBranch = true;
            }
        }
        else if (pathCounter == maxPathCounter)
        {
            createPlatform(endPlatform, platformMoveSpeed);
            pathCounter++;
            playerAnim.Play("PlayerMove");
            AudioManager.instance.PlaySfxByIndex(0);
        }
        else
        {
            pathCounter++;
            playerAnim.Play("PlayerMove");
            AudioManager.instance.PlaySfxByIndex(0);
            bool aPlatformIsMoving = false;
            foreach (Platform pf in platformList)
            {
                aPlatformIsMoving = pf.isMoving;
            }
            //while(aPlatformIsMoving);
            if (!aPlatformIsMoving && !isPaused)
            {


                if (platformList.Count != 0)
                {

                    foreach (Platform pf in platformList)
                    {
                        //Debug.Log(pf.name);
                        pf.Move(platformMoveSpeed);
                    }
                    foreach (Platform pf in rightBranchQueue)
                    {
                        //Debug.Log(pf.name);
                        pf.Move(platformMoveSpeed);
                    }
                    foreach (Platform pf in leftBranchQueue)
                    {
                        //Debug.Log(pf.name);
                        pf.Move(platformMoveSpeed);
                    }
                }

                if (usedSlots == maxPlatformNumber)
                {

                    platformList.Dequeue().Move(platformMoveSpeed);
                    usedSlots--;
                }


                //usedSlots++;
                //platform.Load(p);
                //platform.gameObject.transform.position = new Vector3(6.06f, -4, 0);
                //platform.OnCreate(s);
                //platformList.Enqueue(platform);
            }
        }



    }

    private void createBranchPlatform(PlatformObject p1, PlatformObject p2, float s)
    {
        bool aPlatformIsMoving = false;
        foreach (Platform pf in platformList)
        {
            if (pf.isMoving)
            {
                aPlatformIsMoving = true;
            }
            //aPlatformIsMoving = pf.isMoving;
        }
        //while(aPlatformIsMoving);
        if (!aPlatformIsMoving && !isPaused)
        {
            Platform platform1 = (Platform)Get();
            Platform platform2 = (Platform)Get();

            if (platformList.Count != 0)
            {

                foreach (Platform pf in platformList)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
                foreach (Platform pf in rightBranchQueue)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
                foreach (Platform pf in leftBranchQueue)
                {
                    //Debug.Log(pf.name);
                    pf.Move(s);
                }
            }

            if (usedSlots == maxPlatformNumber)
            {

                platformList.Dequeue().Move(s);
                usedSlots--;
            }
            platform1.branchPosition = 0;
            platform2.branchPosition = 1;
            platform1.Load(p1);
            platform1.gameObject.transform.position += new Vector3(0f, 0f, 1f);
            platform2.gameObject.transform.position += new Vector3(0f, 0f, -1f);
            platform2.Load(p2);

            platform1.OnCreate(s);
            platform2.OnCreate(s);
            leftBranchQueue.Enqueue(platform1);
            rightBranchQueue.Enqueue(platform2);
            usedSlots++;


        }
    }

    public void chooseBranch(int branch)
    {
        
        if(branch == 1)
        {
            //Debug.Log("derecho");
            foreach (Platform pf in rightBranchQueue)
            {
                //Debug.Log(pf.name);
                pf.MoveRight();
            }
            //Debug.Log("izquierdo");
            foreach (Platform pf in leftBranchQueue)
            {
                //Debug.Log(pf.name);
                pf.MoveRight();
            }
            isBranch = false;

            while (rightBranchQueue.Count > 0)
            {

                platformList.Enqueue(rightBranchQueue.Dequeue());
            }

            while (leftBranchQueue.Count > 0)
            {
                leftBranchQueue.Dequeue();
            }
            //Debug.Log(platformList.ToString());
        }
        else if(branch == 0)
        {
            foreach (Platform pf in rightBranchQueue)
            {
                //Debug.Log(pf.name);
                pf.MoveLeft();
            }
            foreach (Platform pf in leftBranchQueue)
            {
                //Debug.Log(pf.name);
                pf.MoveLeft();
            }
            isBranch = false;
            while (leftBranchQueue.Count > 0)
            {
                platformList.Enqueue(leftBranchQueue.Dequeue());
            }
            //leftBranchQueue.Clear();
            while (rightBranchQueue.Count > 0)
            {
                rightBranchQueue.Dequeue();
            }
            //rightBranchQueue.Clear();
            //Debug.Log(platformList.ToString());
        }
    }

    //Patr�n observer


    public void NotifyObservers(int resourceType, int quantity)
    {
        ResourceQuantity resource = new ResourceQuantity(quantity, resourceType);
        for(int i = 0; i< observerList.Count; i++)
        {
            observerList[i].UpdateObserver(resource);
        }
    }

    public void RemoveObserver(IObserver<ResourceQuantity> observer)
    {
        observerList.Remove(observer);
    }

    public void AddObserver(IObserver<ResourceQuantity> observer)
    {
        observerList.Add(observer);
        Debug.Log("Observador a�adido");
    }

    public void DrinkBeer(int quantity)
    {
        beerCount -= quantity;
        drunkCounter += 0.01f * quantity;
        totalBeer += quantity;
        fullscreenMat.SetFloat("_distortionBlend", drunkCounter);
        NotifyObservers(0, -quantity);
        if (beerCount <= 0)
        {
            EndGame(false);
        }

    }

    public void SmokeCigar(int quantity)
    {
        cigarCount -= quantity;
        drunkCounter = 0;
        totalCigar += quantity;
        fullscreenMat.SetFloat("_distortionBlend", drunkCounter);
        NotifyObservers(1, -quantity);
        if (cigarCount <= 0)
        {
            EndGame(false);
        }
    }

    public void AddBeer(int quantity)
    {
        beerCount += quantity;
        NotifyObservers(0, quantity);
        if (beerCount <= 0)
        {
            EndGame(false);
        }
    }
    public void AddCigar(int quantity)
    {
        cigarCount += quantity;
        NotifyObservers(1, quantity);
        if(cigarCount <= 0) 
        {
            EndGame(false);
        } 
    }

    public void EndGame(bool win)
    {
        endGame.SetActive(true);
        isPaused = true;
        isEnded = true;
        TMP_Text gameOver = endGame.GetComponentsInChildren<TMP_Text>()[0];
        TMP_Text pathText = endGame.GetComponentsInChildren<TMP_Text>()[1];
        TMP_Text beerText = endGame.GetComponentsInChildren<TMP_Text>()[2];
        TMP_Text cigarText = endGame.GetComponentsInChildren<TMP_Text>()[3];
        pathText.text = "Has recorrido " + pathCounter.ToString() + " casillas.";
        beerText.text = "Has bebido " + totalBeer.ToString() + " cervezas.";
        cigarText.text = "Has fumado " + totalCigar.ToString() + " cigarros.";
        if(win)
        {
            gameOver.text = "�LO LOGRASTE!";
            AudioManager.instance.PlaySfxByIndex(6);
        }
        else
        {
            gameOver.text = "GAME OVER";
        }
    }

}

