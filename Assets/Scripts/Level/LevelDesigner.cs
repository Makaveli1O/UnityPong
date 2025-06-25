using Assets.Scripts.Blocks;
using Unity.Mathematics;
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
            LoadLevel(GetLevel0());
        }

        public LevelData GetLevel0()
        {
            return new LevelBuilder()
                .WithBlock(BlockColour.Red, 3, 5)
                .WithBlock(BlockColour.Blue, 4, 5)
                .WithCheckerboard(5, 2) // rows x columns
                .Build();
        }

        public void LoadLevel(LevelData levelData)
        {
            foreach (BlockData data in levelData.Blocks)
                _spawner.SpawnBlock(data);
        }
    }
}