using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    
    public class BlockData
    {
        public IBlockBehaviour BlockBehaviour { get; }
        public Shape Shape { get; }
        public Colour Colour { get; }
        public Type Type { get; }
        public int2 Position { get; }

        public BlockData(IBlockBehaviour blockBehaviour, Shape shape, Colour colour, Type type, int2 position)
        {
            BlockBehaviour = blockBehaviour;
            Shape = shape;
            Colour = colour;
            Type = type;
            Position = position;
        }
    }
}