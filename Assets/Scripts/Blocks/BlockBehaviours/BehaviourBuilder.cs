using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BehaviourBuilder
    {
        private readonly List<BehaviourConfig> _configs = new();
        
        public BehaviourBuilder Add<TBehaviour>(Action<Dictionary<string, object>> argsBuilder = null)
        {
            var args = new Dictionary<string, object>();
            argsBuilder?.Invoke(args);
            _configs.Add(new BehaviourConfig(typeof(TBehaviour), args));
            return this;
        }

        public List<BehaviourConfig> Build() => _configs;
    }
}