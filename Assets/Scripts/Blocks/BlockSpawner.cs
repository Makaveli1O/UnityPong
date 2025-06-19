using NUnit.Framework.Internal;
using Unity.Mathematics;
using UnityEngine;
using Assets.Scripts.SharedKernel;

namespace Assets.Scripts.Blocks
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private int _maxBlocks = 10;
        private int _currentBlockCount = 0;

        void Start()
        {
            if (_blockPrefab == null)
            {
                // Throw exception if block prefab is not assigned
                throw new System.Exception("Block prefab is not assigned in the BlockSpawner.");
            }
        }

        public Block SpawnBlock(BlockData blockData)
        {
            Vector2 position = PositionConvertor2D.ToVector2(blockData.Position);
            GameObject block_GO = Instantiate(_blockPrefab, position, Quaternion.identity, transform);
            Block block = block_GO.GetComponent<Block>();
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
