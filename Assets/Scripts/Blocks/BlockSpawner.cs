using UnityEngine;
using Assets.Scripts.SharedKernel;

namespace Assets.Scripts.Blocks
{
    public class BlockSpawner : MonoBehaviour
    {
        private IBlockCounter _blockCounter;
        private IBlockFactory _blockFactory;

        void Awake()
        {
            _blockCounter = SimpleServiceLocator.Resolve<IBlockCounter>();
            _blockFactory = SimpleServiceLocator.Resolve<IBlockFactory>();
            if (_blockFactory == null)
            {
                throw new System.Exception("BlockFactory service is not registered in the SimpleServiceLocator.");
            }

            if (_blockCounter == null)
            {
                throw new System.Exception("BlockCounter service is not registered in the SimpleServiceLocator.");
            }
        }

        public Block SpawnBlock(BlockData blockData)
        {
            Block block = _blockFactory.SpawnBlock(blockData, transform);
            _blockCounter.OnBlockSpawned();

            return block;
        }

        public void DestroyBlock(Block block)
        {
            if (block == null)
            {
                throw new System.Exception("Attempted to destroy a null block.");
            }
            else
            {
                Destroy(block.gameObject);
                _blockCounter.OnBlockDestroyed();
            }
        }
    }
}
