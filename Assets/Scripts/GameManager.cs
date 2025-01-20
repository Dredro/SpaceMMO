using UnityEngine.SceneManagement;

namespace GameSystem
{
    public static class GameManager
    {
        public static void GameReset()
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}