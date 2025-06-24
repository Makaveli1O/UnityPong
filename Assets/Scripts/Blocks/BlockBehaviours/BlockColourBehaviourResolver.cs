using System;
using System.Collections.Generic;
using Assets.Scripts.Blocks.Domain;
using UnityEngine;

namespace Assets.Scripts.Blocks
{

    public class BlockColourBehaviourResolver : IBlockBehaviourResolver
    {
        public List<Type> Resolve(BlockColour color)
        {
            return color switch
            {
                BlockColour.Red => new() { typeof(ExplodeBehaviour) },
                BlockColour.Blue => new() { typeof(MoveBehaviour) },
                BlockColour.Purple => new() { typeof(ExplodeBehaviour), typeof(MoveBehaviour) },
                _ => new()
            };
        }

        public static Color ToColour(BlockColour colour)
        {
            return colour switch
            {
                BlockColour.Red => new Color(1f, 0f, 0f),
                BlockColour.Blue => new Color(0f, 0f, 1f),
                BlockColour.Purple => new Color(0.5f, 0f, 0.5f),
                _ => new Color(1f, 1f, 1f)
            };
        }
    }

}