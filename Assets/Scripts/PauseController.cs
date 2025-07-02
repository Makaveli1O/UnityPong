using Assets.Scripts.GameHandler;
using Assets.Scripts.SharedKernel;
using UnityEngine;

public class PauseController : MonoBehaviour, IPauseController
{
    private IGameStateController _gameStateController;
    private ISceneLoader _sceneLoader;

    void Awake()
    {
        _gameStateController = SimpleServiceLocator.Resolve<IGameStateController>();
        _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
    }

    public void OnContinueClicked()
    {
        gameObject.SetActive(false);
        _gameStateController.SetState(GameState.Playing);
    }

    public void OnExitClicked()
    {
        Time.timeScale = 1f;
        _sceneLoader.LoadScene(SceneNames.MainMenu);
    }

    public void Pause()
    {
        gameObject.SetActive(true);
        _gameStateController.SetState(GameState.Paused);
    }

    public void UnPause()
    {
        gameObject.SetActive(false);
        _gameStateController.SetState(GameState.Playing);
    }
}
