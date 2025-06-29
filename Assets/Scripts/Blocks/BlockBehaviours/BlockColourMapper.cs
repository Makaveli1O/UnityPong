using UnityEngine;

namespace Assets.Scripts.Blocks
{

    public class BlockColourMapper
    {
        public static Color ToColour(BlockColour colour)
        {
            return colour switch
            {
                BlockColour.Red => new Color(1f, 0f, 0f), //RED
                BlockColour.Blue => new Color(0f, 0f, 1f), //BLUE
                BlockColour.Purple => new Color(0.5f, 0f, 0.5f), //PURPLE
                _ => new Color(1f, 1f, 1f)
            };
        }
    }

}