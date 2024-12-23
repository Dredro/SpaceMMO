using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Stats : ISubject
{
    public string id;
    [SerializeField] public int Health;
    [SerializeField] public int Energy;

    public List<IObserver> Observers { get; set; } = new();

    public void AttachObserver(IObserver observer)
    {
        if (Observers.Contains(observer)) return;
        Observers.Add(observer);
    }

    public void DetachObserver(IObserver observer)
    {
        if (!Observers.Contains(observer)) return;
        Observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in Observers) observer.Notify();
    }
}