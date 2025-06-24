using UnityEngine;

namespace GameHandler{
    public class GameOver : MonoBehaviour
    {
        private const string _sceneName = "GameOver";
        private void OnCollisionEnter2D(Collision2D collision)
        {
            SceneLoader.LoadScene(_sceneName);
        }
    }
}