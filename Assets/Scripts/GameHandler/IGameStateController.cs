using System;

namespace Assets.Scripts.GameHandler
{
    public interface IGameStateController
    {
        GameState CurrentState { get; }
        void SetState(GameState newState);
        event Action<GameState> OnStateChanged;
    }
}