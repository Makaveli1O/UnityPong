using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks;
using Unity.Mathematics;

namespace Assets.Scripts.Level
{
    public class LevelBuilder
    {
        private readonly List<BlockData> _entries = new();

        public LevelBuilder WithBlock(BlockColour colour, int2 position)
        {
            var behaviourConfigs = GetDefaultBehavioursForColour(colour);

            _entries.Add(new BlockData(
                null,
                colour,
                position,
                behaviourConfigs
            ));
            return this;
        }

        public LevelBuilder WithBlock(
            BlockColour colour,
            int2 position,
            List<BehaviourConfig> behaviourConfigs
        )
        {
            if (behaviourConfigs == null)
                throw new ArgumentNullException(nameof(behaviourConfigs));
                
            _entries.Add(
                new BlockData(
                    null,
                    colour,
                    position,
                    behaviourConfigs
                )
            );
            return this;
        }


        public LevelData Build()
        {
            return new LevelData { Blocks = _entries };
        }

        private List<BehaviourConfig> GetDefaultBehavioursForColour(BlockColour colour)
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
    }

}