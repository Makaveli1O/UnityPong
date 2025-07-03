using UnityEngine;

namespace Assets.Scripts.Score
{
    public class ScoreTracker : MonoBehaviour, IScoreTracker
    {
        private float _startTime;
        private bool _tracking;
        private int _score;

        public int CurrentScore => _score;
        public bool IsTrackingEnabled => _tracking;

        public void StartTracking()
        {
            _score = 0;
            _startTime = Time.time;
            _tracking = true;
        }

        public void BlockDestroyed()
        {
            if (!_tracking) return;

            float timeSinceStart = Time.time - _startTime;

            int basePoints = 100;
            float bonus = Mathf.Clamp(1000f / Mathf.Max(1f, timeSinceStart), 0, 500); // Optional cap on bonus
            int total = Mathf.RoundToInt(basePoints + bonus);

            _score += total;
        }

        public void StopTracking()
        {
            _tracking = false;
        }

        public int GetFinalScore() => _score;
    }
}
