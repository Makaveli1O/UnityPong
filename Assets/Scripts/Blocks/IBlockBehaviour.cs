namespace Assets.Scripts.Blocks
{
    public interface IBlockBehaviour
    {
        public void Behaviour(); // Method to define the block's behavior
        public void OnHit(); // Method to perform an action when the block is hit
    }
}