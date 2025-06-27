using Assets.Scripts.SharedKernel;
using UnityEngine;
namespace Assets.Scripts.Blocks
{
    public class MoveBehaviour : MonoBehaviour, IUpdateBehaviour, IConfigurableBehaviour
    {
        public float speed  = 0.5f;
        public Vector3 pointA;
        public Vector3 pointB;
        private float time;

        void Start()
        {
            pointA = transform.position;
            pointB = Utils2D.GetAxisAlignedVisiblePoint(transform.position);
            pointB.z = pointA.z;
        }

        public void Execute(Block context)
        {
            MoveBackAndForth();
        }

        private void MoveBackAndForth()
        {
            time += Time.deltaTime * speed;
            float t = Mathf.PingPong(time, 1f);
            transform.position = Vector3.Lerp(pointA, pointB, t);
        }
    }
}
