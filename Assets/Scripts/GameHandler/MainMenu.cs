using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.GameHandler
{
    public class MainMenu : MonoBehaviour
    {
        private const string _level0Scene = "Level0";
        private ISceneLoader _sceneLoader;

        void Awake()
        {
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
        }

        public void PlayGame()
        {
            _sceneLoader.LoadScene(_level0Scene);
        }
    }

}