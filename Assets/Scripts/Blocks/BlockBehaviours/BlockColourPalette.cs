using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public static class BlockColourPalette
    {
        private static readonly Dictionary<BlockColour, Color> _colours = new()
        {
            [BlockColour.Red] = Color.red,
            [BlockColour.Blue] = Color.blue,
        };

        public static Color GetColor(BlockColour colour) => _colours[colour];
    }

}