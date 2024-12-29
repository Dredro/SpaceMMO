using System;
using ObserverPattern;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class UIEnergy : MonoBehaviour,IObserver
{
    private TextMeshProUGUI _textMeshProUGUI;

    private void Awake()
    {
        _textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }
  
    public void Notify(ISubject subject,string message)
    {
        Debug.Log($"Notify : {subject} {message}");
        if(message != SubjectMessageConst.EnergyUpdateMessage) return;
        if (subject is Stats stats)
        {
            _textMeshProUGUI.text = stats.Energy.ToString();
        }
    }
}