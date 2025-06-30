using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.GameHandler
{
    public class MainMenu : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private string GetInitialSceneName => SceneNames.Level0;

        void Awake()
        {
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
        }

        public void PlayGame()
        {
            _sceneLoader.LoadScene(GetInitialSceneName);
        }
    }

}