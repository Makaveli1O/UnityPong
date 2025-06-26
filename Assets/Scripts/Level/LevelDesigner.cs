using System.Collections.Generic;
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
                .WithBlock(
                    BlockColour.Blue,
                    new int2(3,4),
                    new List<Block.BehaviourConfig>
                    {
                        new(
                            typeof(MoveBehaviour), new Dictionary<string, object>
                                {
                                    { "speed", 10f }
                                }
                            )
                    }
                )
                .Build();
        }

        public void LoadLevel(LevelData levelData)
        {
            foreach (BlockData data in levelData.Blocks)
                _spawner.SpawnBlock(data);
        }
    }
}