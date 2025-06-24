/*
using NUnit.Framework;
using UnityEngine;
using Assets.Scripts.GameHandler;

[TestFixture]
public class GameHandlerTests
{
    private GameHandler _handler;
    private StubSceneLoader _sceneLoader;
    private StubWinCondition _winCondition;

    [SetUp]
    public void SetUp()
    {
        _winCondition = new StubWinCondition();
        _sceneLoader = new StubSceneLoader();
        
        _handler = new GameObject().AddComponent<GameHandler>();
        _handler.Init(_winCondition, _sceneLoader);
    }

    [TearDown]
    public void TearDown()
    {
        Object.DestroyImmediate(_handler.gameObject);
    }

    [Test]
    public void StartsInPlayingState()
    {
        _handler.SetState(GameState.Playing);
        Assert.AreEqual(GameState.Playing, _handler.CurrentState);
    }

    [Test]
    public void TransitionToPaused()
    {
        _handler.SetState(GameState.Playing);
        _handler.SetState(GameState.Paused);

        Assert.AreEqual(GameState.Paused, _handler.CurrentState);
    }

    [Test]
    public void TransitionToWin_WhenWinConditionMet()
    {
        _handler.SetState(GameState.Playing);
        _winCondition.Result = true;

        _handler.TickWinCondition(); // Simulates Update()

        Assert.AreEqual(GameState.Win, _handler.CurrentState);
        Assert.AreEqual("WinScene", _sceneLoader.LastLoadedScene);
    }

    [Test]
    public void TransitionToGameOver_LoadsScene()
    {
        _handler.SetState(GameState.GameOver);
        Assert.AreEqual("GameOverScene", _sceneLoader.LastLoadedScene);
    }
}

*/