using System;
using UnityEngine;

public class UIEnergy : MonoBehaviour,IObserver
{
    private Stats _stats;
    private void Awake()
    {
        _stats = GetComponent<Player>().stats;
    }

    public void Notify()
    {
        
    }
}