using System;
using System.Collections.Generic;
using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockColourResolver
    {
        private static readonly Dictionary<Type, Color> _behaviourColours = new()
        {
            [typeof(MoveBehaviour)] = Color.blue,
            [typeof(ExplodeBehaviour)] = Color.red,
        };
        public static Color Resolve(List<BehaviourConfig> behaviours)
        {
            var colours = new List<Color>();

            foreach (var behaviour in behaviours)
            {
                if (_behaviourColours.TryGetValue(behaviour.BehaviourType, out var blockColour))
                    colours.Add(blockColour);
            }

            return Utils2D.BlendColours(colours);
        }
    }
}