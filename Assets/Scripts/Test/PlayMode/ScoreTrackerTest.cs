using Assets.Scripts.Score;
using NUnit.Framework;
using UnityEngine;

public class ScoreTrackerTest
{
    private ScoreTracker _tracker;

    [SetUp]
    public void SetUp()
    {
        _tracker = new GameObject("ScoreTracker").AddComponent<ScoreTracker>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_tracker.gameObject);
    }

    [Test]
    public void StartsWithZeroScore()
    {
        Assert.AreEqual(0, _tracker.CurrentScore);
    }

    [Test]
    public void IncrementsDestroyedBlocks()
    {
        _tracker.StartTracking();
        _tracker.BlockDestroyed();
        _tracker.BlockDestroyed();
        _tracker.StopTracking();

        Assert.Greater(_tracker.GetFinalScore(), 0);
    }

    [Test]
    public void FastDestruction_YieldsHigherScore()
    {
        _tracker.StartTracking();
        _tracker.BlockDestroyed();
        _tracker.StopTracking();

        int fastScore = _tracker.GetFinalScore();

        _tracker.StartTracking();
        _tracker.BlockDestroyed();
        // Simulate longer time
        typeof(ScoreTracker).GetField("_startTime", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)!
            .SetValue(_tracker, Time.time - 10f);
        _tracker.StopTracking();

        int slowScore = _tracker.GetFinalScore();

        Assert.Greater(fastScore, slowScore);
    }

    [Test]
    public void StopTracking_MakesScoreImmutable()
    {
        _tracker.StartTracking();
        _tracker.BlockDestroyed();
        _tracker.StopTracking();

        int scoreBefore = _tracker.GetFinalScore();
        _tracker.BlockDestroyed(); // should have no effect
        int scoreAfter = _tracker.GetFinalScore();

        Assert.AreEqual(scoreBefore, scoreAfter);
    }
}
