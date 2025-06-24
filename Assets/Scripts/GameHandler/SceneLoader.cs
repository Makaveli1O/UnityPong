using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameHandler
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        private string _currentScene = null;
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            _currentScene = sceneName;
        }
    }
}