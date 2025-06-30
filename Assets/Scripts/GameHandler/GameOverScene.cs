using Assets.Scripts.GameHandler;
using Assets.Scripts.SharedKernel;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    private ISceneLoader _sceneLoader;

    void Awake()
    {
        _sceneLoader = SimpleServiceLocator.Resolve<ISceneLoader>();
    }

    public void BackToMenu()
    {
        _sceneLoader.LoadScene(SceneNames.MainMenu);
    }
}
