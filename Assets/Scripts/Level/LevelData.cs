using System.Collections.Generic;
using Assets.Scripts.Blocks;

namespace Assets.Scripts.Level
{
    // List of individual block details within level
    public class LevelData
    {
        public List<BlockData> Blocks { get; set; } = new();
    }
}