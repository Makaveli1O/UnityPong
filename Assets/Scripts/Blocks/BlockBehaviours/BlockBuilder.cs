using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockBuilder
    {
        private readonly GameObject _go;
        private readonly Block _block;
        private readonly IBlockBehaviourResolver _resolver;

        public BlockBuilder(GameObject go, IBlockBehaviourResolver resolver)
        {
            _go = go;
            _block = go.GetComponent<Block>();
            _resolver = resolver;
        }

        public BlockBuilder WithData(BlockData data)
        {
            _block.SetData(data);
            return this;
        }

        public BlockBuilder WithColour(BlockColour colour)
        {
            _block.SetColour(BlockColourBehaviourResolver.ToColour(colour));
            return this;
        }

        public BlockBuilder AddBehavioursForColour(BlockColour colour)
        {
            foreach (var type in _resolver.Resolve(colour))
            {
                var instance = (MonoBehaviour)_go.AddComponent(type);
                if (instance is IUpdateBehaviour update)
                    _block.AddUpdateBehaviour(update);
                if (instance is ICollisionBehaviour collision)
                    _block.AddCollisionBehaviour(collision);
            }

            return this;
        }

        public Block Build()
        {
            return _block;
        }
    }
}