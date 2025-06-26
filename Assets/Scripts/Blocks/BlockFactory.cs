using System;
using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockFactory : MonoBehaviour, IBlockFactory
    {
        [SerializeField] private GameObject _blockPrefab;
        [SerializeField] private IBlockBehaviourResolver _resolver;

        /// <summary>
        /// Awake is called when the script instance is being loaded.
        /// </summary>
        void Awake()
        {
            _resolver = SimpleServiceLocator.Resolve<IBlockBehaviourResolver>();
        }

        public Block SpawnBlock(BlockData data, Transform parent)
        {
            if (_blockPrefab == null) throw new Exception("Block prefab not assigned.");
            if (_resolver == null) throw new Exception("BlockFactory missing behaviour resolver.");

            GameObject go = Instantiate(
                _blockPrefab,
                Utils2D.PositionConvertor2D.ToVector2(data.Position),
                Quaternion.identity,
                parent
            );

            Block block = new BlockBuilder(go)
                .AddBehaviours(data.Behaviours)
                .WithData(data)
                .Build();
                

            return block;
        }
    }

}