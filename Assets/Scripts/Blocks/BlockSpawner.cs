using NUnit.Framework.Internal;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private int _maxBlocks = 10;
        private int _currentBlockCount = 0;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (_blockPrefab == null)
            {
                // Throw exception if block prefab is not assigned
                throw new System.Exception("Block prefab is not assigned in the BlockSpawner.");
            }

            Block block = SpawnBlock(new BlockData(null, null, null, null, Vector2.zero));
        }

        public Block SpawnBlock(BlockData blockData)
        {
            GameObject block_GO = Instantiate(_blockPrefab, blockData.Position, Quaternion.identity, transform);
            Block block = block_GO.GetComponent<Block>();
            return block;
        }
    }
}
