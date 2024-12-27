using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPool
{
    public IPooleableObject Get();
    public void Release(IPooleableObject obj);
}
