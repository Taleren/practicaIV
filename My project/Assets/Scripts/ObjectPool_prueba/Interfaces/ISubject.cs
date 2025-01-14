using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface ISubject
{
    void NotifyObservers();
    void RemoveObserver(IObserver observer);
    void AddObserver(IObserver observer);

}
