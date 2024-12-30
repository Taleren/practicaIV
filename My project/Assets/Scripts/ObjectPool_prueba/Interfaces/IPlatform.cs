using Patterns.ObjectPool.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlatform
{
    public void Load(PlatformObject po);
    public void OnCreate(float s);

    public void Move(float s);
    public void MoveLeft();
    public void MoveRight();

}
