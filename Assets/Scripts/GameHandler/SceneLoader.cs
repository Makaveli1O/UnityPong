using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameHandler
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public string GetCurrentSceneName => SceneManager.GetActiveScene().name;
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}