using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    
    public class BlockData
    {
        public IBlockBehaviour BlockBehaviour { get; }
        public BlockShape Shape { get; }
        public BlockColour Colour { get; }
        public BlockType Type { get; }
        public int2 Position { get; }

        public BlockData(IBlockBehaviour blockBehaviour, BlockShape shape, BlockColour colour, BlockType type, int2 position)
        {
            BlockBehaviour = blockBehaviour;
            Shape = shape;
            Colour = colour;
            Type = type;
            Position = position;
        }
    }
}