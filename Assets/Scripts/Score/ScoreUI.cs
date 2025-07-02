using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Score
{
    public class ScoreUI : MonoBehaviour
    {
        [SerializeField] private Text _scoreText;

        void Start()
        {
            _scoreText.text = $"Final Score: {ScoreKeeper.FinalScore}";
        }
    }
}