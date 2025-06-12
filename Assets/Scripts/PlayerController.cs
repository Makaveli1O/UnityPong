using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;        // Paddle movement speed
    [SerializeField] private float boundY = 3.8f;     // Vertical boundary limit
    private Vector2 moveInput;
    public InputAction playerControls;

    private void Start()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate new position using the y component of the input
        Vector2 paddlePosition = transform.position;
        paddlePosition.y += moveInput.y * speed * Time.deltaTime;
        
        // Clamp the paddle position to stay within bounds
        paddlePosition.y = Mathf.Clamp(paddlePosition.y, -boundY, boundY);
        
        // Update paddle position
        transform.position = paddlePosition;


    }
}
