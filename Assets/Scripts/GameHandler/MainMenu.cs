using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandler
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneLoader.LoadNextScene();
        }
    }

}