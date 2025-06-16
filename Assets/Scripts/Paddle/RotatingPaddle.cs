using UnityEngine;
using UnityEngine.InputSystem;

public class RotatingPaddle : MonoBehaviour, IPaddleBehaviour
{
    private const float defaultAngle = 0f;
    private const float rotateLeftAngle = -45f;
    private const float rotateRightAngle = 45f;
    private const float speed = 5f;
    private float _paddleAngle = 0f;
    public float Speed => speed;
    public void Action(InputAction.CallbackContext ctx)
    {
        Vector2 rotationInput = ctx.ReadValue<Vector2>();
        if (ctx.performed)
        {
            RotatePaddle(rotationInput);
        }
        else if (ctx.canceled)
        {
            RotatePaddle(defaultAngle);
        }
    }

    private void RotatePaddle(Vector2 rotationInput)
    {
        if (rotationInput.Equals(Vector2.right))
        {
            _paddleAngle = rotateRightAngle;
        }
        else if (rotationInput.Equals(Vector2.left))
        {
            _paddleAngle = rotateLeftAngle;
        }

        transform.rotation = Quaternion.Euler(0, 0, _paddleAngle);
    }

    private void RotatePaddle(float angle)
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
