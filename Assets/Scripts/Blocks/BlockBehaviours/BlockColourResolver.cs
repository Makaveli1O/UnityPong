using System;
using System.Collections.Generic;
using Assets.Scripts.SharedKernel;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public class BlockColourResolver
    {
        private static readonly Dictionary<Type, BlockColour> _behaviourColours = new()
        {
            [typeof(MoveBehaviour)] = BlockColour.Blue,
            [typeof(ExplodeBehaviour)] = BlockColour.Red,
        };
        public static Color Resolve(List<BehaviourConfig> behaviours)
        {
            var colours = new List<Color>();

            foreach (var behaviour in behaviours)
            {
                if (_behaviourColours.TryGetValue(behaviour.BehaviourType, out var blockColour))
                    colours.Add(BlockColourPalette.GetColor(blockColour));
            }

            return Utils2D.BlendColours(colours);
        }
    }
}