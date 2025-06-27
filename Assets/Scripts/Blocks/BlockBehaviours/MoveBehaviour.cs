using Assets.Scripts.SharedKernel;
using UnityEngine;
namespace Assets.Scripts.Blocks
{
    public class MoveBehaviour : MonoBehaviour, IUpdateBehaviour, IConfigurableBehaviour
    {
        public float speed = 0.5f;
        public Vector3 endMovementPoint = Vector3.zero;
        private Vector3 _initialPosition;
        private bool _initialized = false;
        private float time;

        public void OnUpdateExecute(Block context)
        {
            if (!_initialized) Initialize(context);
            MoveBackAndForth();
        }

        private void MoveBackAndForth()
        {
            time += Time.deltaTime * speed;
            float t = Mathf.PingPong(time, 1f);
            transform.position = Vector3.Lerp(_initialPosition, endMovementPoint, t);
        }

        private void Initialize(Block context)
        {
            _initialPosition = new Vector3(context.Data.Position.x, context.Data.Position.y);
            if (endMovementPoint.Equals(Vector3.zero))
                endMovementPoint = Utils2D.GetAxisAlignedVisiblePoint(_initialPosition);

            _initialized = true;
        }
    }
}
