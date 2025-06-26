using System.Collections.Generic;
using Assets.Scripts.Block;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockBuilder
    {
        private readonly GameObject _go;
        private readonly Block _block;

        public BlockBuilder(GameObject go)
        {
            _go = go;
            _block = go.GetComponent<Block>();
        }

        public BlockBuilder WithData(BlockData data)
        {
            _block.SetData(data);
            return this;
        }

        public BlockBuilder AddBehaviours(List<BehaviourConfig> behaviourConfigs)
        {
            foreach (var config in behaviourConfigs)
            {
                var instance = (MonoBehaviour)_go.AddComponent(config.BehaviourType);

                if (instance is IConfigurableBehaviour configurable && config.Parameters != null)
                {
                    configurable.Configure(config.Parameters);
                }

                if (instance is IUpdateBehaviour update)
                    _block.AddUpdateBehaviour(update);
                if (instance is ICollisionBehaviour collision)
                    _block.AddCollisionBehaviour(collision);
            }

            return this;
        }

        public BlockBuilder WithColour(Color color)
        {
            _block.SetColour(color);
            return this;
        }

        public Block Build()
        {
            return _block;
        }
    }

}