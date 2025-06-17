using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _paddlePrefab;
    private GameObject _paddleInstance;
    private IPaddleBehaviour _paddle;
    private PlayerControls _playerControls;
    private Vector2 _movementVector;

    private float _verticalBoundary;

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    void Start()
    {
        _verticalBoundary = CalculateYBoundary();
        _paddleInstance = Instantiate(_paddlePrefab, transform.position, Quaternion.identity, transform);
        _paddle = _paddleInstance.GetComponent<IPaddleBehaviour>();

        if (_paddle == null)
        {
            //Throw exception if paddle prefab is not assigned or component is not present
            throw new Exception("IPaddleBehaviour not implemented on the paddle GameObject.");
        }

    }

    private void Update()
    {
        // Movement
        Vector2 currentPosition = transform.position;

        currentPosition.y += _movementVector.y * _paddle.Speed * Time.deltaTime;
        transform.position = currentPosition;

        // Boundary check
        ClampToVerticalBounds();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _movementVector = ctx.ReadValue<Vector2>();
        }
        else if (ctx.canceled)
        {
            _movementVector = Vector2.zero;
        }
    }

    public void OnRotate(InputAction.CallbackContext ctx)
    {
        _paddle.Action(ctx);
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
        float halfPaddleHeight = _paddlePrefab.GetComponent<SpriteRenderer>().bounds.extents.y;
        return camHeight - halfPaddleHeight;
    }
}
