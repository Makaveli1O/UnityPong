using Assets.Scripts.Blocks;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelDesigner : ILevelDesigner
    {
        private BlockSpawner _blockSpawner;

        public void LoadLevel(LevelData levelData)
        {
            foreach (BlockData blockData in levelData.Blocks)
            {
                _blockSpawner.SpawnBlock(blockData);
            }
        }
    }
}