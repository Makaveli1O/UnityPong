using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScoreTracker : MonoBehaviour, IScoreTracker
    {
        private int _destroyedBlocks = 0;
        private float _startTime;
        private float _endTime;
        private bool _tracking = false;

        public int CurrentScore { get; private set; }

        public void StartTracking()
        {
            _destroyedBlocks = 0;
            _startTime = Time.time;
            _tracking = true;
        }

        public void BlockDestroyed()
        {
            if (!_tracking) return;
            _destroyedBlocks++;
        }

        public void StopTracking()
        {
            _tracking = false;
            _endTime = Time.time;

            float duration = Mathf.Max(1f, _endTime - _startTime);
            float speedBonus = 10000f / duration;
            CurrentScore = Mathf.RoundToInt(_destroyedBlocks * 100 + speedBonus);
        }

        public int GetFinalScore() => CurrentScore;
    }
}