public class BlockWinConditionCounter : IGameWinCondition, IBlockCounter
{
    private int _activeBlockCount = 0;
    private bool _initialized = false;
    public bool IsWinConditionMet() => _initialized && _activeBlockCount == 0;

    public void OnBlockSpawned()
    {
        _initialized = true;
        _activeBlockCount++;
    }

    public void OnBlockDestroyed()
    {
        _activeBlockCount--;
    }
}