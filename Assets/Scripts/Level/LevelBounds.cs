using Assets.Scripts.GameHandler;
using TMPro;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    public enum WallScreenPosition
    {
        Left,
        Right,
        Bottom,
        Top
    }
    private float _wallThickness = 1f;
    private float _left = 0f;
    private float _right = 0f;
    private float _top = 0f;
    private float _bottom = 0f;
    private float _width = 0f;
    private float _height = 0f;
    [SerializeField] private Sprite _wallSprite;

    void Start()
    {
        CreateBounds();
    }

    private void InitializeLevelBounds()
    {
        Camera cam = Camera.main;
        
        _height = 2f * cam.orthographicSize;
        _width = _height * cam.aspect;

        _left = cam.transform.position.x - _width / 2f;
        _right = cam.transform.position.x + _width / 2f;
        _top = cam.transform.position.y + _height / 2f;
        _bottom = cam.transform.position.y - _height / 2f;
    }

    public void CreateBounds()
    {
        InitializeLevelBounds();

        float hudOffsetInUnits = 50f * Camera.main.orthographicSize * 2f / Screen.height;

        CreateWall(
            new Vector2((_left + _right) / 2f,
            _top + _wallThickness / 2f - hudOffsetInUnits),
            new Vector2(_width, _wallThickness),
            WallScreenPosition.Top
        );
        CreateWall(
            new Vector2((_left + _right) / 2f,
            _bottom - _wallThickness / 2f),
            new Vector2(_width, _wallThickness),
            WallScreenPosition.Bottom
        );
        CreateWall(
            new Vector2(_left - _wallThickness / 2f,
            (_top + _bottom) / 2f),
            new Vector2(_wallThickness, _height),
            WallScreenPosition.Left
        );
        CreateWall(
            new Vector2(_right + _wallThickness / 2f,
            (_top + _bottom) / 2f),
            new Vector2(_wallThickness, _height),
            WallScreenPosition.Right
        );
    }

    private void CreateWall(Vector2 position, Vector2 size, WallScreenPosition wallPosition)
    {
        GameObject wall;
        switch (wallPosition)
        {
            case WallScreenPosition.Left:
                wall = new GameObject("LeftWall");
                wall.AddComponent<GameOverTrigger>();
                break;
            case WallScreenPosition.Right:
                wall = new GameObject("RightWall");
                break;
            case WallScreenPosition.Bottom:
                wall = new GameObject("BottomWall");
                break;
            case WallScreenPosition.Top:
                wall = new GameObject("TopWall");
                break;
            default:
                wall = new GameObject("LeftWall");
                break;
        }
        wall.transform.position = position;

        var collider = wall.AddComponent<BoxCollider2D>();
        collider.size = size;
        collider.isTrigger = false;

        wall.AddComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        var sr = wall.AddComponent<SpriteRenderer>();
        sr.sprite = _wallSprite;
        sr.drawMode = SpriteDrawMode.Sliced;
        sr.color = Color.white;
    }
}
