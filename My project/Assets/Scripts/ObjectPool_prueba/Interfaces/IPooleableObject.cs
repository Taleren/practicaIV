using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPooleableObject
{
    public bool Active
    {
        get;
        set;
    }

    public void Reset();

}
