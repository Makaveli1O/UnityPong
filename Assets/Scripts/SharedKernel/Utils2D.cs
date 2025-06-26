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

        /// <summary>
        /// Returns a random point inside the visible camera viewport in world space.
        /// </summary>
        /// <param name="camera">Camera to use, defaults to main camera if null.</param>
        public static Vector3 GetRandomVisiblePoint(Camera camera = null)
        {
            if (camera == null) camera = Camera.main;

            // Random point in viewport (x,y between 0 and 1)
            float x = UnityEngine.Random.Range(0f, 1f);
            float y = UnityEngine.Random.Range(0f, 1f);

            Vector3 viewportPoint = new Vector3(x, y, camera.nearClipPlane);

            // Convert viewport to world point
            Vector3 worldPoint = camera.ViewportToWorldPoint(viewportPoint);

            // Set z = 0 for 2D world space
            worldPoint.z = 0f;

            return worldPoint;
        }

        public static Vector3 GetAxisAlignedVisiblePoint(Vector3 origin)
        {
            Camera cam = Camera.main;
            Vector3 viewPos = cam.WorldToViewportPoint(origin);
            Vector3 targetViewport = viewPos;

            if (UnityEngine.Random.value < 0.5f)
            {
                // Horizontal movement
                targetViewport.x = UnityEngine.Random.Range(0.1f, 0.9f);
            }
            else
            {
                // Vertical movement
                targetViewport.y = UnityEngine.Random.Range(0.1f, 0.9f);
            }

            Vector3 world = cam.ViewportToWorldPoint(new Vector3(targetViewport.x, targetViewport.y, viewPos.z));
            world.z = origin.z;
            return world;
        }
     
    }
}
