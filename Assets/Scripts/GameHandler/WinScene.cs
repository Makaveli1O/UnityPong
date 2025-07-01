using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.GameHandler
{
    public class WinScene : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private ISoundPlayer _soundPlayer;
        private string GetInitialSceneName => SceneNames.Level0;
        public AudioClip GetSceneMusicTheme => Resources.Load<AudioClip>("Sound/UI/Themes/win_game");

        void Awake()
        {
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
            _soundPlayer = SimpleServiceLocator.Resolve<ISoundPlayer>();
        }

        void Start()
        {
            _soundPlayer.PlayMusic(GetSceneMusicTheme);
        }

        public void PlayGame()
        {
            _sceneLoader.LoadScene(GetInitialSceneName);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

    }

}