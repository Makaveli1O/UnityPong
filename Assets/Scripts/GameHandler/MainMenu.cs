using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameHandler
{
    public class MainMenu : MonoBehaviour
    {
        private const string _level0Scene = "Level0";

        public void PlayGame()
        {
            SceneLoader.LoadScene(_level0Scene);
        }
    }

}