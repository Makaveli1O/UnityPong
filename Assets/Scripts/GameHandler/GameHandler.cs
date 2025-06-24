using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.GameHandler
{
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private string _winScene = "WinScene";
        [SerializeField] private string _gameOverScene = "GameOverScene";
        private IGameWinCondition _winCondition;
        private GameState _currentState;
        private ISceneLoader _sceneLoader;

        private void Awake()
        {
            _winCondition = new BlockWinConditionCounter();
            _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
        }

        private void Start()
        {
            SetState(GameState.Playing);
        }

        private void Update()
        {
            if (_currentState == GameState.Playing && _winCondition.IsWinConditionMet())
            {
                SetState(GameState.Win);
            }
        }

        public void SetState(GameState newState)
        {
            if (_currentState == newState)
                return;

            _currentState = newState;
            HandleStateChange(newState);
        }

        private void HandleStateChange(GameState state)
        {
            switch (state)
            {
                case GameState.Playing:
                    Time.timeScale = 1f;
                    break;
                case GameState.Paused:
                    Time.timeScale = 0f;
                    break;
                case GameState.GameOver:
                    Time.timeScale = 0f;
                    _sceneLoader.LoadScene(_gameOverScene);
                    break;
                case GameState.Win:
                    Time.timeScale = 0f;
                    _sceneLoader.LoadScene(_winScene);
                    break;
            }
        }
    }
}
