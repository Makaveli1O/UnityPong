using UnityEngine;
using Assets.Scripts.SharedKernel;

namespace Assets.Scripts.GameHandler{
    public class GameOverTrigger : MonoBehaviour
    {
        private string GetSceneName => SceneNames.GameOver;
        private ISceneLoader _sceneLoader;

        void Awake()
        {
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ball"))
                _sceneLoader.LoadScene(GetSceneName);
        }
    }
}