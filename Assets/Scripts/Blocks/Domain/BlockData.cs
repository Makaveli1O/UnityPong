using Assets.Scripts.Blocks.Domain;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    /// <summary>
    /// Value object - represents the data for a block, including its behaviour, shape, colour, type, and position.
    /// </summary>
    /// <param name="blockBehaviour">The behaviour implementation associated with the block.</param>
    /// <param name="shape">The shape of the block.</param>
    /// <param name="colour">The colour of the block.</param>
    /// <param name="type">The type of the block.</param>
    /// <param name="position">The position of the block as an <see cref="int2"/>.</param>
    public record BlockData
    {
        public BlockShape Shape { get; }
        public BlockColour Colour { get; }
        public int2 Position { get; }

        public BlockData(BlockShape shape, BlockColour colour, int2 position)
        {
            Shape = shape;
            Colour = colour;
            Position = position;
        }
    }
}