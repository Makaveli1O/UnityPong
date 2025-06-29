using System;

namespace Assets.Scripts.Blocks
{
    public record BehaviourConfig
    {
        public Type BehaviourType { get; set; }
        public object Config { get; }

        public BehaviourConfig(Type behaviourType, object config)
        {
            BehaviourType = behaviourType;
            Config = config;
        }
    }
}