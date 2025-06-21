using System;

namespace Assets.Scripts.Blocks
{
    public interface IBlockBehaviour
    {
        public void Execute(Block context);
    }
}