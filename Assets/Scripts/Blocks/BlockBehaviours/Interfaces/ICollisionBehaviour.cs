using UnityEngine;

namespace Assets.Scripts.Blocks
{
    // This interface defines a behaviour that can handle collision events for blocks.
    public interface ICollisionBehaviour : IBlockBehaviour
    {
        void OnCollisionExecute(Block context, Collision2D collision);
     }
}