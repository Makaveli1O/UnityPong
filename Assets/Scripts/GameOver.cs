using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Load the Game Over scene
        SceneManager.LoadScene(2);
    }
}