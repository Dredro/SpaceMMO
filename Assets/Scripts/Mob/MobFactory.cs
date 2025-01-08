using UnityEngine;

namespace Mob
{
    public class MobFactory : MonoBehaviour
    {
        [Header("Mob Prefabs")] [SerializeField]
        private GameObject aggressiveMobPrefab;

        [SerializeField] private GameObject supportingMobPrefab;
        [SerializeField] private GameObject resourceProvidingMobPrefab;

        [Header("Parent for Mobs")] [SerializeField]
        private Transform mobsParent;

        void Start()
        {
            CreateAggressiveMob("Goblin", 100, 25);
            CreateSupportingMob("Healer", 80, 15);
            CreateResourceProvidingMob("Gatherer", 90);
        }

        public void CreateAggressiveMob(string name, int health, int damage)
        {
            if (aggressiveMobPrefab == null)
            {
                Debug.LogError("Aggressive Mob Prefab is not assigned.");
                return;
            }

            GameObject mobObject = Instantiate(aggressiveMobPrefab, mobsParent);
            Mob mob = mobObject.GetComponent<Mob>();
            if (mob == null)
            {
                Debug.LogError("Aggressive Mob Prefab does not have a Mob component.");
                return;
            }

            MobBuilder builder = new MobBuilder(mob);
            builder.SetName(name)
                .SetHealth(health)
                .SetBehaviour(new AggressiveBehaviour { Damage = damage })
                .Build();

            mob.PerformBehaviour();
        }

        public void CreateSupportingMob(string name, int health, int healAmount)
        {
            if (supportingMobPrefab == null)
            {
                Debug.LogError("Supporting Mob Prefab is not assigned.");
                return;
            }

            GameObject mobObject = Instantiate(supportingMobPrefab, mobsParent);
            Mob mob = mobObject.GetComponent<Mob>();
            if (mob == null)
            {
                Debug.LogError("Supporting Mob Prefab does not have a Mob component.");
                return;
            }

            MobBuilder builder = new MobBuilder(mob);
            builder.SetName(name)
                .SetHealth(health)
                .SetBehaviour(new SupportingBehaviour { HealAmount = healAmount})
                .Build();

            mob.PerformBehaviour();
        }

        public void CreateResourceProvidingMob(string name, int health)
        {
            if (resourceProvidingMobPrefab == null)
            {
                Debug.LogError("Resource Providing Mob Prefab is not assigned.");
                return;
            }

            GameObject mobObject = Instantiate(resourceProvidingMobPrefab, mobsParent);
            Mob mob = mobObject.GetComponent<Mob>();
            if (mob == null)
            {
                Debug.LogError("Resource Providing Mob Prefab does not have a Mob component.");
                return;
            }

            MobBuilder builder = new MobBuilder(mob);
            builder.SetName(name)
                .SetHealth(health)
                .SetBehaviour(new ResourceProvidingBehaviour {})
                .Build();

            mob.PerformBehaviour();
        }
    }
}