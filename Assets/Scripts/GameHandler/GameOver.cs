using Assets.Scripts.SharedKernel;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO remove this is not ccorrect responsiblity
        SceneManager.LoadScene("GameOver");
    }
}