using System;
using System.Collections.Generic;
using ObserverPattern;
using UnityEditor;
using UnityEngine;

[Serializable]
public class Stats : ISubject
{
    public string id;

    [SerializeField]
    private int health;

    public int Health
    {
        get => health;
        set
        {
            health = value;
            NotifyObservers(SubjectMessageConst.HealthUpdateMessage);
        }
    }

    [SerializeField]
    private int energy;

    public int Energy
    {
        get => energy;
        set
        {
            energy = value;
            NotifyObservers(SubjectMessageConst.EnergyUpdateMessage);
        }
    }

    public int Damage { get; set; } = 1;
    public int Armor { get; set; } = 0;

    public List<IObserver> Observers { get; set; } = new();
    
    public void AttachObserver(IObserver observer)
    {
        if (Observers.Contains(observer)) return;
        Observers.Add(observer);
        Debug.Log($"Observer attached{observer}");
    }

    public void DetachObserver(IObserver observer)
    {
        if (!Observers.Contains(observer)) return;
        Observers.Remove(observer);
        Debug.Log($"Observer detached{observer}");
    }

    public void NotifyObservers(string message)
    {
        foreach (var observer in Observers) observer.Notify(this,message);
    }
}