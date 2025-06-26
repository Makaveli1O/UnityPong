using System;

namespace Assets.Scripts.Block
{
    public record BehaviourConfig(Type BehaviourType, System.Collections.Generic.Dictionary<string, object> Parameters)
    {
        public Type BehaviourType { get; set; } = BehaviourType;
        public System.Collections.Generic.Dictionary<string, object> Parameters { get; set; } = Parameters;
    }
}