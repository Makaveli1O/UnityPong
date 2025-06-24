using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockFactory : MonoBehaviour, IBlockFactory
    {
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private IBlockBehaviourResolver _resolver;
        private List<Block> _spawnedBlocks = new();

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            _resolver = SimpleServiceLocator.Resolve<IBlockBehaviourResolver>();
        }

        /// <summary>
        /// Start is called on the frame when a script is enabled just before
        /// any of the Update methods is called the first time.
        /// </summary>
        void Start()
        {
            if (_blockPrefab == null)
            {
                throw new Exception("Block prefab is not assigned in the inspector.");
            }

            if (_resolver == null)
            {
                throw new Exception("BlockFactory not initialized with behaviour resolver.");
            }
        }

        public Block SpawnBlock(BlockData blockData, Transform parent)
        {
            if (_blockPrefab == null) throw new Exception("Block prefab is not assigned.");
            if (_resolver == null) throw new Exception("BlockFactory not initialized with behaviour resolver.");

            GameObject go = InstantiateBlockGameObjectOnPosition(blockData.Position, parent);

            // Get colour behaviours
            var colourBehaviours = _resolver.Resolve(blockData.Colour);

            foreach (var behaviour in colourBehaviours)
            {
                go.AddComponent(behaviour);
            } 

            Block block = go.GetComponent<Block>();

            block.Initialize(blockData);

            return block;
        }

        private GameObject InstantiateBlockGameObjectOnPosition(int2 position, Transform parent)
        {
            Vector2 pos = Utils2D.PositionConvertor2D.ToVector2(position);
            GameObject go = Instantiate(_blockPrefab, pos, Quaternion.identity, parent);

            Block block = go.GetComponent<Block>();

            if (block != null) _spawnedBlocks.Add(block);

            if (block == null) throw new Exception("Block component not found on the prefab.");

            return go;
        }
    }
}