using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BehaviourBuilder
    {
        private readonly List<BehaviourConfig> _configs = new();
        
        public BehaviourBuilder Add<TBehaviour, TConfig>(TConfig config)
        {
            _configs.Add(new BehaviourConfig(typeof(TBehaviour), config!));
            return this;
        }

        public List<BehaviourConfig> Build() => _configs;
    }
}