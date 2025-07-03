namespace Assets.Scripts.Score
{
    public interface IScoreTracker
    {
        void StartTracking();
        void BlockDestroyed();
        void StopTracking();
        int GetFinalScore();
        int CurrentScore { get; }
        public bool IsTrackingEnabled { get; }
    }
}