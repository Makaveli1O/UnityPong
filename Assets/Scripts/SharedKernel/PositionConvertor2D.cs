using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.SharedKernel
{
    public class PositionConvertor2D
    {

        public static Vector2 ToVector2(int2 value)
        {
            return new Vector2(value.x, value.y);
        }

        public static int2 ToInt2(Vector2 value)
        {
            return new int2((int)value.x, (int)value.y);
        }
    }   
}
