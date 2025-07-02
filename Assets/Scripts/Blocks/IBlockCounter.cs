namespace Assets.Scripts.Blocks
{
    public interface IBlockCounter
    {
        void OnBlockSpawned(Block ctx);
        void OnBlockDestroyed();
    }
}