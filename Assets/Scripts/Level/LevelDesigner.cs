using Assets.Scripts.Blocks;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelDesigner : MonoBehaviour, ILevelDesigner
    {
        private BlockSpawner _spawner;

        void Awake()
        {
            _spawner = GetComponent<BlockSpawner>();
        }

        void Start()
        {
            // TODO remove. Just testing purposes

            var level = new LevelBuilder()
                .WithCheckerboard(5, 5)
                .Build();

            LoadLevel(level);
        }

        public void LoadLevel(LevelData levelData)
        {
            foreach (BlockData data in levelData.Blocks)
                _spawner.SpawnBlock(data);
        }
    }
}