using Assets.Scripts.Blocks;

public class StubWinCondition : IGameWinCondition
{
    public bool Result;
    public bool IsWinConditionMet() => Result;
}