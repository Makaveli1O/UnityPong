using Assets.Scripts.Score;
using Assets.Scripts.SharedKernel;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

namespace Assets.Scripts.GameHandler
{
    public class WinScene : MonoBehaviour
    {
        private ISceneLoader _sceneLoader;
        private ISoundPlayer _soundPlayer;
        private IScoreTracker _scoreTracker;
        private string GetInitialSceneName => SceneNames.Level0;
        public AudioClip GetSceneMusicTheme => Resources.Load<AudioClip>("Sound/UI/Themes/win_game");
        [SerializeField] private Text _text;
        void Awake()
        {
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
            _soundPlayer = SimpleServiceLocator.Resolve<ISoundPlayer>();
        }

        void Start()
        {
            _text.text += ScoreKeeper.FinalScore;
            _soundPlayer.PlaySfx(GetSceneMusicTheme);
        }

        public void LoadMainMenu()
        {
            _sceneLoader.LoadScene(SceneNames.MainMenu);
        }
    }
}