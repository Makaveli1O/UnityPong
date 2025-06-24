using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameHandler
{
    public class SceneLoader : MonoBehaviour, ISceneLoader
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}