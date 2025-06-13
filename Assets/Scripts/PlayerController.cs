using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // Paddle movement speed
    [SerializeField] private float boundY = 3.8f;     // Vertical boundary limit
    [SerializeField] private float dashPower = 10f;
    private Rigidbody2D _rb;
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnMove(InputValue value)
    {
        var movementVector = value.Get<Vector2>();
        _rb.linearVelocity = movementVector * speed;
    }

    private void OnDash()
    {
        _rb.AddForce(Vector2.right * dashPower, ForceMode2D.Impulse);
    }
}
