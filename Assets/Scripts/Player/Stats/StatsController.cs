using UnityEngine;

namespace PlayerSystem
{
    public class StatsController
    {
        private static StatsController _instance;
        private Stats _stats = new Stats();

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

        public void SetArmor(int value)
        {
            _stats.Armor = value;
        }
    }
}