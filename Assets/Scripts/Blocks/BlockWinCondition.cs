namespace Assets.Scripts.Blocks
{
    public class BlockWinConditionCounter : IGameWinCondition, IBlockCounter
    {
        private int _activeBlockCount;
        private bool _initialized;
        public bool IsWinConditionMet() => _initialized && _activeBlockCount == 0;

        public BlockWinConditionCounter()
        {
            _activeBlockCount = 0;
            _initialized = false;
        }

        public void ResetCounter()
        {
            _activeBlockCount = 0;
            _initialized = false;
        }

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
}