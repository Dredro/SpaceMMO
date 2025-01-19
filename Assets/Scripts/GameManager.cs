using UnityEngine.SceneManagement;

namespace Enhance
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