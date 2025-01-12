using UnityEngine;

public class SnakeHeadMovement : MonoBehaviour
{

    static SnakeHeadMovement instance;
    public static SnakeHeadMovement Instance { get { return instance; } }
    Vector2 direction;
    Vector2 snakeBodyPosition;
    [Header("Move Info")]
    public float moveRate;
    public float timer;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        snakeBodyPosition = Vector2.zero;
        direction = Vector2.up;

    }
    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        PlayerInput();
        MoveSnake();

    }


    private void RotateSprite()
    {
        if (direction.y == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction.y == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (direction.x == 1)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (direction.x == -1)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
    }

    public void MoveSnake()
    {
        if (timer <= 0)
        {
            timer = moveRate;
            snakeBodyPosition += direction;
            ScreenWrap();
            transform.position = new Vector2(snakeBodyPosition.x, snakeBodyPosition.y);
            RotateSprite();
        }
    }
    private void ScreenWrap()
    {
        if (snakeBodyPosition.y >= 8)
        {
            snakeBodyPosition.y = -7;
        }
        else if (snakeBodyPosition.y <= -8)
        {
            snakeBodyPosition.y = 6;
        }
        else if (snakeBodyPosition.x <= -13)
        {
            snakeBodyPosition.x = 12;
        }
        else if (snakeBodyPosition.x >= 14)
        {
            snakeBodyPosition.x = -12;
        }
    }


}
