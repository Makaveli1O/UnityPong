using NUnit.Framework.Internal;
using Unity.Mathematics;
using UnityEngine;
using Assets.Scripts.SharedKernel;
using Assets.Scripts.Blocks.Domain;
using Mono.Cecil;

namespace Assets.Scripts.Blocks
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private int _maxBlocks = 10;
        private int _currentBlockCount = 0;
        private IBlockCounter _blockCounter;
        private IBlockFactory _blockFactory;

        void Awake()
        {
            _blockFactory = SimpleServiceLocator.Resolve<IBlockFactory>();
            if (_blockFactory == null)
            {
                throw new System.Exception("BlockFactory service is not registered in the SimpleServiceLocator.");
            }
        }

        public Block SpawnBlock(BlockData blockData)
        {
            if (_currentBlockCount >= _maxBlocks)
            {
                throw new System.Exception("Maximum block limit reached. Cannot spawn more blocks.");
            }

            Block block = _blockFactory.SpawnBlock(blockData, transform);
            _currentBlockCount++;

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
                _currentBlockCount--;
            }
        }
    }
}
