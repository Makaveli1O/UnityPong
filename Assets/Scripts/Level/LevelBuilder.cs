using System.Collections.Generic;
using Assets.Scripts.Block;
using Assets.Scripts.Blocks;
using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.Level
{
    public class LevelBuilder
    {
        private readonly List<BlockData> _entries = new();

        List<BehaviourConfig> GetDefaultBehavioursForColour(BlockColour colour)
        {
            return colour switch
            {
                BlockColour.Red => new List<BehaviourConfig> 
                { 
                    new BehaviourConfig(typeof(ExplodeBehaviour), new Dictionary<string, object>()) 
                },
                BlockColour.Blue => new List<BehaviourConfig> 
                { 
                    new BehaviourConfig(typeof(MoveBehaviour), new Dictionary<string, object>
                    {
                        { "speed", 0.5f }
                    })
                },
                _ => new List<BehaviourConfig>()
            };
        }

        public LevelBuilder WithBlock(BlockColour colour, int x, int y)
        {
            var behaviourConfigs = GetDefaultBehavioursForColour(colour);

            _entries.Add(new BlockData(
                null,
                colour,
                new int2(x, y),
                behaviourConfigs
            ));
            return this;
        }


        public LevelData Build()
        {
            return new LevelData { Blocks = _entries };
        }
    }

}