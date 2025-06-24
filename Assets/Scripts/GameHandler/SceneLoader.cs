using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandler{
    public class SceneLoader : MonoBehaviour
    {
        public static void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // TODO do not use scene index in the future when all the scenes are correctly named
        public static void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}