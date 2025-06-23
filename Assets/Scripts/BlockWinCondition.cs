public class BlockWinCondition : IGameWinCondition, IBlockCounter
{
    private int _activeBlockCount;
    public bool IsWinConditionMet() => _activeBlockCount == 0;

    public void OnBlockSpawned()
    {
        _activeBlockCount++;
    }

    public void OnBlockDestroyed()
    {
        _activeBlockCount--;
    }
}