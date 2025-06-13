using Unity.VisualScripting;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private float gravityScale = -9.81f;
    void Awake()
    {
        Physics2D.gravity = new Vector2(gravityScale, 0);
    }
}
