using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlatformLoader : MonoBehaviour, IObjectPool
{
    public static PlatformLoader Instance;

    [SerializeField] private List<PlatformObject> platformObjects;
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject platformParent;
    private List<Platform> poolablePlatforms = new List<Platform>(); 
    int activePlatforms = 0;
    int totalPoolSize = 6;

    [SerializeField] private float platformMoveSpeed;

    public int maxPlatformNumber = 4;
    private Queue<Platform> platformList = new Queue<Platform>();
    
    Vector3 lastPlatformPos = new Vector3(6.0999999f,-4f, -0.14738825f);

    int probabilityTotal;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

      
        
    }

    // Start is called before the first frame update
    void Start()
    {
        poolablePlatforms.Add(platformPrefab.GetComponent<Platform>());
        platformPrefab.GetComponent<Platform>().Active = false;
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
        if (activePlatforms < maxPlatformNumber)
        {
            createPlatform(platformObjects[0], platformMoveSpeed/2);
        }
    }

    public void createPlatform(PlatformObject p, float s)
    {
        bool aPlatformIsMoving = false;
        foreach (Platform pf in platformList)
        {
            aPlatformIsMoving = pf.isMoving;
        }
        //while(aPlatformIsMoving);
        if (!aPlatformIsMoving)
        {
            Platform platform = (Platform)Get();


            if (platformList.Count != 0)
            {

                foreach (Platform pf in platformList)
                {
                    Debug.Log(pf.name);
                    pf.Move(s);
                }
            }

            if (platformList.Count == maxPlatformNumber)
            {

                platformList.Dequeue().Move(s);

            }

            platform.Load(p);

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

    private void createRandomPlatform()
    {
        int random = Random.Range(0, probabilityTotal);
        int i = 0;
        while (i < platformObjects.Count - 1 && random < platformObjects[i].appearRatio)
        {
            i++;
            random -= platformObjects[i].appearRatio;
        }
        createPlatform(platformObjects[i], platformMoveSpeed);
    }

}

