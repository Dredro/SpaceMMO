namespace Quest
{
    using System.Collections.Generic;
    using System.IO;
    using UnityEngine;

    public class QuestManager : MonoBehaviour
    {
        public static QuestManager Instance;

        private List<IQuest> activeQuests = new List<IQuest>();
        private string saveFilePath;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            saveFilePath = Path.Combine(Application.persistentDataPath, "quests.json");
            LoadQuestStates();
        }

        public void AddQuest(IQuest quest)
        {
            activeQuests.Add(quest);
            Debug.Log($"Added quest: {quest.Name}");
        }

        public void CompleteQuest(IQuest quest)
        {
            quest.Complete();
            SaveQuestStates();
        }

        public void SaveQuestStates()
        {
            var serializedQuests = JsonUtility.ToJson(new QuestStateWrapper { Quests = activeQuests });
            File.WriteAllText(saveFilePath, serializedQuests);
            Debug.Log("Quest states saved.");
        }

        public void LoadQuestStates()
        {
            if (File.Exists(saveFilePath))
            {
                var json = File.ReadAllText(saveFilePath);
                var wrapper = JsonUtility.FromJson<QuestStateWrapper>(json);
                activeQuests = wrapper.Quests;
                Debug.Log("Quest states loaded.");
            }
            else
            {
                Debug.Log("No saved quest states found.");
            }
        }
    }

    [System.Serializable]
    public class QuestStateWrapper
    {
        public List<IQuest> Quests;
    }

}