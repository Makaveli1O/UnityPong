using System.Collections.Generic;
using Assets.Scripts.Blocks;
using Unity.Mathematics;

namespace Assets.Scripts.Level
{
    public class LevelBuilder
    {
        private readonly List<BlockData> _entries = new();

        public LevelBuilder WithBlock(BlockColour colour, int x, int y)
        {
            _entries.Add(
                new BlockData(
                    null,
                    colour,
                    new int2(x, y)
                )
            );
            return this;
        }

        public LevelBuilder WithRow(BlockColour colour, int y, int length)
        {
            for (int x = 0; x < length; x++)
                WithBlock(colour, x, y);

            return this;
        }

        public LevelBuilder WithCheckerboard(int width, int height)
        {
            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                {
                    var colour = (x + y) % 2 == 0 ? BlockColour.Red : BlockColour.Blue;
                    WithBlock(colour, x, y);
                }
            return this;
        }

        public LevelData Build()
        {
            return new LevelData { Blocks = _entries };
        }
    }
}