
using Assets.Scripts.Blocks;
using Assets.Scripts.SharedKernel;
using UnityEngine;

public class MoveBehaviour : MonoBehaviour, IUpdateBehaviour
{
    public Vector3 pointB;
    public float speed = 1.0f;
    private Vector3 pointA;
    private float distance = 0f;
    private float time = 0f;
    [SerializeField] private const float minMoveRange = 1f;
    [SerializeField] private const float maxMoveRange = 3f;

    void Start()
    {
        pointA = transform.position;
        pointB = Utils2D.GetRandomVisiblePoint(transform.position, minMoveRange, maxMoveRange);
    }

    public void Execute(Block context)
    {
        MoveBackAndForth(context);
    }

    private void MoveBackAndForth(Block context)
    {
        time += Time.deltaTime * speed;
        transform.position = Vector3.Lerp(pointA, pointB, Mathf.PingPong(time, 1));
    }
}