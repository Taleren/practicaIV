using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlatform", menuName = "ScriptableObjects/PlatformInfo")]

public class PlatformObject : ScriptableObject
{
    [SerializeField] public string name;
    [SerializeField] public Color32 colorTest;
    [SerializeField] public string eventTest;
    
    public int appearRatio;
    //int platformType;

    //IEvent platformEvent;
}
