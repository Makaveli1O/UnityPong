using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{

    public class BlockColourMapper
    {
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