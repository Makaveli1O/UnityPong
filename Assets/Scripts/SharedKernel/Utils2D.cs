using Unity.Mathematics;
using UnityEngine;

namespace Assets.Scripts.SharedKernel
{
    public class Utils2D
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

        public static Vector3 GetRandomVisiblePoint(Vector3 origin, float minRange, float maxRange)
        {
            Camera cam = Camera.main;
            if (cam == null) return origin;

            Vector3 screenPos = cam.WorldToViewportPoint(origin);

            float maxOffsetX = Mathf.Min(maxRange, 1f - screenPos.x);
            float minOffsetX = Mathf.Min(maxRange, screenPos.x);
            float maxOffsetY = Mathf.Min(maxRange, 1f - screenPos.y);
            float minOffsetY = Mathf.Min(maxRange, screenPos.y);

            float offsetX = UnityEngine.Random.Range(minRange, Mathf.Min(maxRange, maxOffsetX + minOffsetX));
            float offsetY = UnityEngine.Random.Range(minRange, Mathf.Min(maxRange, maxOffsetY + minOffsetY));

            offsetX *= UnityEngine.Random.value > 0.5f ? 1 : -1;
            offsetY *= UnityEngine.Random.value > 0.5f ? 1 : -1;

            Vector3 target = origin + new Vector3(offsetX, offsetY, 0);

            // Clamp to viewport to make sure it's visible
            Vector3 viewportTarget = cam.WorldToViewportPoint(target);
            viewportTarget.x = Mathf.Clamp(viewportTarget.x, 0.05f, 0.95f);
            viewportTarget.y = Mathf.Clamp(viewportTarget.y, 0.05f, 0.95f);

            return cam.ViewportToWorldPoint(viewportTarget);
        }
    }
}
