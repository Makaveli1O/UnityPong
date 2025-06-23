using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Game
{
    //TODO use event system instead of checking in update whethe ror not win condition is met
    public class GameHandler : MonoBehaviour
    {
        [SerializeField] private string _winScene = "WinScene";
        [SerializeField] private string _gameOverScene = "GameOverScene";

        private IGameWinCondition _winCondition;
        private GameState _currentState;

        private void Awake()
        {
            _winCondition = new BlockWinCondition();
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
                    SceneLoader.LoadScene(_gameOverScene);
                    break;
                case GameState.Win:
                    Time.timeScale = 0f;
                    SceneLoader.LoadScene(_winScene);
                    break;
            }
        }
    }
}
