using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public interface ISubject<T>
{
    void NotifyObservers(int resourceType, int quantity);
    void RemoveObserver(IObserver<T> observer);
    void AddObserver(IObserver<T> observer);

}
