using Assets.Scripts.SharedKernel;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Load the Game Over scene
        var sceneLoader = SimpleServiceLocator.Resolve<SceneLoader>();
        sceneLoader.LoadScene("GameOver");
    }
}