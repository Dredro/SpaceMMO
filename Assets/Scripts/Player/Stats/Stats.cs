using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class Stats : ISubject
    {
        public string ID;

        private float _health;

        public float Health
        {
            get => _health;
            set
            {
                _health = value;
                NotifyObservers(SubjectMessageConst.HealthUpdateMessage);
            }
        }

        [SerializeField] private int _energy;

        public int Energy
        {
            get => _energy;
            set
            {
                _energy = value;
                NotifyObservers(SubjectMessageConst.EnergyUpdateMessage);
            }
        }

        public int Damage { get; set; } = 25;
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
            foreach (var observer in Observers) observer.Notify(this, message);
        }
    }
}