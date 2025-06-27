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
                    new int2(0, 4),
                    new List<BehaviourConfig>
                    {
                        new(
                            typeof(MoveBehaviour), new Dictionary<string, object>
                                {
                                    { "speed", 0.2f }
                                }
                            )
                    }
                )
                .WithBlock(
                    BlockColour.Blue,
                    new int2(1, 1),
                    new List<BehaviourConfig>
                    {
                        new(
                            typeof(MoveBehaviour), new Dictionary<string, object>
                                {
                                    { "speed", 1f }
                                }
                            )
                    }
                )
                .WithBlock(
                    BlockColour.Blue,
                    new int2(2, 3),
                    new List<BehaviourConfig>
                    {
                        new(
                            typeof(MoveBehaviour), new Dictionary<string, object>
                                {
                                    { "speed", 5f }
                                }
                            )
                    }
                )
                .WithBlock(
                    BlockColour.Red,
                    new int2(0, 5),
                    new List<BehaviourConfig>
                    {
                        new(typeof(ExplodeBehaviour), new Dictionary<string, object>{})
                    }
                )
                    .WithBlock(
                    BlockColour.Red,
                    new int2(2, 2),
                    new List<BehaviourConfig>
                    {
                        new(typeof(ExplodeBehaviour), new Dictionary<string, object>{})
                    }
                )
                .WithBlock(
                    BlockColour.Red,
                    new int2(2, 0),
                    new List<BehaviourConfig>
                    {
                        new(typeof(ExplodeBehaviour), new Dictionary<string, object>{})
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