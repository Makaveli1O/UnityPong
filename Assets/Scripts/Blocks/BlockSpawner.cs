using UnityEngine;
using Assets.Scripts.SharedKernel;
using Unity.Mathematics;

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
            Vector3 gridPosition = new Vector3(blockData.Position.x, blockData.Position.y, 0);
            Block block = _blockFactory.SpawnBlock(
                blockData with
                {
                    Position = new int2(
                        (int)gridPosition.x,
                        (int)gridPosition.y
                    )
                },transform
            );
            block.transform.position = gridPosition;

            _blockCounter.OnBlockSpawned(block);
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
                _blockCounter.OnBlockDestroyed();
                Destroy(block.gameObject);
            }
        }
    }
}
