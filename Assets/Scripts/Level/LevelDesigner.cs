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
            var behavioursBlueBasic = new BehaviourBuilder()
                .Add<MoveBehaviour, MoveConfig>(
                    new MoveConfig(
                        1.0f,
                        new Vector3(-3f, -3f, 0f),
                        new Vector3(1f, -3f, 0f)
                    )
                )
                .Build();
            
            var behavioursRedBasic = new BehaviourBuilder()
                .Add<ExplodeBehaviour, ExplodeConfig>(new ExplodeConfig())
                .Build();
                
            var combinedBasicBehaviours = new BehaviourBuilder()
                .Add<MoveBehaviour, MoveConfig>(
                    new MoveConfig(
                        10.0f,
                        new Vector3(3f, 3f, 0f),
                        new Vector3(1f, 3f, 0f)
                    )
                )
                .Add<ExplodeBehaviour, ExplodeConfig>(new ExplodeConfig())
                .Build();

            return new LevelBuilder()
                .WithBlock(
                    new int2(3, 4),
                    behavioursBlueBasic
                )
                .WithBlock(
                    new int2(-3, -4),
                    behavioursRedBasic
                )
                .WithBlock(
                    new int2(-1,-1),
                    combinedBasicBehaviours
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