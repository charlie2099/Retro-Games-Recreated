using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    [SerializeField] private Transform _snakePartInFront;
    private Vector2Int _gridPosition;
    private Vector2Int _gridMoveDirection;
    private float _gridMoveTimer;
    private float _gridMoveTimerMax;

    private void Awake()
    {
        _gridPosition = new Vector2Int(0, 0);
        _gridMoveTimerMax = 0.25F;
        _gridMoveTimer = _gridMoveTimerMax;
        _gridMoveDirection = new Vector2Int(1, 0); // Start moving right by default at start of game
    }

    private void Update()
    {
        HandleInput();
        HandleGridMovement();

        // Head movement
        /*if (_snakePartInFront == null)
        {
            transform.Translate(Vector2.right * (_speed * Time.deltaTime));
        }*/
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Only move UP if NOT already moving DOWN
            if (_gridMoveDirection.y != -1)
            {
                _gridMoveDirection.x = 0;
                _gridMoveDirection.y = +1;
            }
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            // Only move DOWN if NOT already moving UP
            if (_gridMoveDirection.y != +1)
            {
                _gridMoveDirection.x = 0;
                _gridMoveDirection.y = -1;
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Only move RIGHT if NOT already moving LEFT
            if (_gridMoveDirection.x != -1)
            {
                _gridMoveDirection.x = +1;
                _gridMoveDirection.y = 0;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Only move LEFT if NOT already moving RIGHT
            if (_gridMoveDirection.x != +1)
            {
                _gridMoveDirection .x = -1;
                _gridMoveDirection.y = 0;
            }
        }
    }
    
    private void HandleGridMovement()
    {
        // Sync grid movement timer with game clock
        _gridMoveTimer += Time.deltaTime;

        // Every x seconds update the grid position of the snake
        if (_gridMoveTimer >= _gridMoveTimerMax)
        {
            _gridPosition += _gridMoveDirection;
            _gridMoveTimer -= _gridMoveTimerMax;
        }
        
        transform.position = new Vector3(_gridPosition.x + 0.5F, _gridPosition.y + 0.5F);
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(_gridMoveDirection) + 90);
    }

    private float GetAngleFromVector(Vector2Int direction)
    {
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (n < 0)
        {
            n += 360;
        }
        return n;
    }
}
