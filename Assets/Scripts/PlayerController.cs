using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // Paddle movement speed
    private PlayerControls playerControls;
    private Vector2 _movementVector;
    private float _paddleAngle = 0f;
    private float _verticalBoundary;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    void Start()
    {
        _verticalBoundary = CalculateYBoundary();
    }

    private void Update()
    {
        // Movement
        Vector2 currentPosition = transform.position;

        currentPosition.y += _movementVector.y * speed * Time.deltaTime;
        transform.position = currentPosition;

        // Boundary check
        ClampToVerticalBounds();

        //Rotation
        transform.rotation = Quaternion.Euler(0, 0, _paddleAngle);
    }

    private void ClampToVerticalBounds()
    {
        var pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, -_verticalBoundary, _verticalBoundary);
        transform.position = pos;
    }

    private float CalculateYBoundary()
    {
        float camHeight = Camera.main.orthographicSize;
        float halfPaddleHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
        return camHeight - halfPaddleHeight;
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _movementVector = ctx.ReadValue<Vector2>();
        }

        if (ctx.canceled)
        {
            _movementVector = Vector2.zero;
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Vector2 rotationInput = ctx.ReadValue<Vector2>();
            if (rotationInput.Equals(Vector2.right))
            {
                _paddleAngle = 45f;
            }
            else if (rotationInput.Equals(Vector2.left))
            {
                _paddleAngle = -45f;
            }
        }

        if (ctx.canceled)
        {
            _paddleAngle = 0f;
        }
    }
}
