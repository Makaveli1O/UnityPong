using UnityEngine;

namespace Assets.Scripts.Blocks
{
    public record MoveConfig
    {
        public float Speed;
        public Vector3 EndPoint;
        public Vector3 StartPoint;

        public MoveConfig(float speed, Vector3 startPoint, Vector3 endPoint)
        {
            Speed = speed;
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}