using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "newPlatform", menuName = "ScriptableObjects/PlatformInfo")]



public class PlatformObject : ScriptableObject
{
    public enum platformEventEnum
    {
        standard,
        testDialogue,
        barDialogue,
        smokeDialogue,
        endEvent,
        mikeEvent,
        sheriffEvent,
        shellyEvent,
        humeEvent,
        badguyEvent

            
    };

    public string name;

    //[SerializeField] public Color32 colorTest;
    //[SerializeField] public string eventTest;

    public int appearRatio;
    //int platformType;

    public platformEventEnum platformEvent;

    public Mesh model;

    public Mesh npc;
}
