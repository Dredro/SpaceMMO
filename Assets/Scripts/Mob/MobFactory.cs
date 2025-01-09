using UnityEngine;
using UnityEngine.Serialization;

namespace Mob
{
    public class MobFactory : MonoBehaviour
    {
        [Header("Mob Prefabs")] 
        [SerializeField] private GameObject aggressiveMobPrefab;
        [SerializeField] private GameObject neutralMobPrefab;
        [SerializeField] private GameObject friendlyMobPrefab;

        [Header("Parent for Mobs")] 
        [SerializeField] private Transform mobsParent;

        void Start()
        {
            CreateAggressiveMob("Goblin", 100, 25);
            CreateNeutralMob("Healer", 80, 15);
            CreateFriendlyMob("Gatherer", 90);
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

        public void CreateNeutralMob(string name, int health, int healAmount)
        {
            if (neutralMobPrefab == null)
            {
                Debug.LogError("neutral Mob Prefab is not assigned.");
                return;
            }

            GameObject mobObject = Instantiate(neutralMobPrefab, mobsParent);
            Mob mob = mobObject.GetComponent<Mob>();
            if (mob == null)
            {
                Debug.LogError("Neutral Prefab does not have a Mob component.");
                return;
            }

            MobBuilder builder = new MobBuilder(mob);
            builder.SetName(name)
                .SetHealth(health)
                .SetBehaviour(new NeutralBehaviour())
                .Build();

            mob.PerformBehaviour();
        }

        public void CreateFriendlyMob(string name, int health)
        {
            if (friendlyMobPrefab == null)
            {
                Debug.LogError("Friendly Mob Prefab is not assigned.");
                return;
            }

            GameObject mobObject = Instantiate(friendlyMobPrefab, mobsParent);
            Mob mob = mobObject.GetComponent<Mob>();
            if (mob == null)
            {
                Debug.LogError("Friendly Mob Prefab does not have a Mob component.");
                return;
            }

            MobBuilder builder = new MobBuilder(mob);
            builder.SetName(name)
                .SetHealth(health)
                .SetBehaviour(new FriendlyBehaviour {})
                .Build();

            mob.PerformBehaviour();
        }
    }
}