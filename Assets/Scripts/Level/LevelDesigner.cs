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
            var behaviours = new BehaviourBuilder()
                .Add<MoveBehaviour>(args => args["speed"] = 10f)
                .Build();
            
            // TODO FIX CREATION OF BEHAVIOUR IN A BETTER WAY
            return new LevelBuilder()
                .WithBlock(
                    BlockColour.Red,
                    new int2(2, 2),
                    new List<BehaviourConfig> { new(typeof(ExplodeBehaviour), new Dictionary<string, object> { }) }
                )
                .WithBlock(
                    BlockColour.Blue,
                    new int2(3, 4),
                    behaviours
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