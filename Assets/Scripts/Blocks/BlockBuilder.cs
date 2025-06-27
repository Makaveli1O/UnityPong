using System.Collections.Generic;
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
            foreach (BehaviourConfig config in behaviourConfigs)
            {
                MonoBehaviour instance = (MonoBehaviour)_go.AddComponent(config.BehaviourType);

                if (instance is IConfigurableBehaviour)
                    if (config.Parameters != null)
                        instance = Configure(instance, config);
                    else
                        throw new System.Exception("Provided parameters for configurable behaviours are invalid.");

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

        // Configre the configurable behaviour of the block
        private MonoBehaviour Configure(MonoBehaviour instance, BehaviourConfig config)
        {
            foreach (var param in config.Parameters)
            {
                var field = config.BehaviourType.GetField(param.Key);
                if (field != null)
                {
                    field.SetValue(instance, param.Value);
                    continue;
                }

                var prop = config.BehaviourType.GetProperty(param.Key);
                if (prop != null && prop.CanWrite)
                {
                    prop.SetValue(instance, param.Value);
                }
            }

            return instance;
        }
    }

}