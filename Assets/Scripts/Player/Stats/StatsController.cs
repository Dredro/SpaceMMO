using System;
using ObserverPattern;
using UnityEditor;
using UnityEngine;

public class StatsController
{
    private static StatsController? _instance;
    private Stats _stats = new Stats();
    private StatsController()
    {
    }

    public static StatsController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new StatsController();
            }
            return _instance;
        }
    }
    public void AttachBasicObservers(Stats stats, UIHealth healthObserver, UIEnergy energyObserver)
    {
        if (healthObserver != null)
        {
            stats.AttachObserver(healthObserver);
            stats.NotifyObservers(SubjectMessageConst.HealthUpdateMessage);
        }
        else Debug.LogWarning("UIHealth observer not found!");

        if (energyObserver != null)
        {
            stats.AttachObserver(energyObserver);
            stats.NotifyObservers(SubjectMessageConst.EnergyUpdateMessage);
        }
        else Debug.LogWarning("UIEnergy observer not found!");
    }
    public Stats GetStats(string id)
    {
        return new Stats
        {
            Energy = 100,
            Health = 100
        };
    }
    public void AddEnergy(Stats stats, int amount)
    {
        stats.Energy += amount;
        if (stats.Energy > 100)
        {
            stats.Energy = 100; // Cap at maximum value
        }
    }

    public void RemoveEnergy(Stats stats, int amount)
    {
        stats.Energy -= amount;
        if (stats.Energy < 0)
        {
            stats.Energy = 0; // Prevent negative values
        }
    }

    public void AddHealth(Stats stats, int amount)
    {
        stats.Health += amount;
        if (stats.Health > 100)
        {
            stats.Health = 100; // Cap at maximum value
        }
    }

    public void RemoveHealth(Stats stats, int amount)
    {
        stats.Health -= amount;
        if (stats.Health < 0)
        {
            stats.Health = 0; // Prevent negative values
        }
    }
}