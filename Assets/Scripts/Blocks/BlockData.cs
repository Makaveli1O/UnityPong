using System.Collections.Generic;
using Unity.Mathematics;

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
        public int2 Position { get; set; }
        public List<BehaviourConfig> Behaviours { get; set; }

        public BlockData(BlockShape shape, int2 position, List<BehaviourConfig> behaviours)
        {
            Shape = shape;
            Position = position;
            Behaviours = behaviours;
        }
    }
}