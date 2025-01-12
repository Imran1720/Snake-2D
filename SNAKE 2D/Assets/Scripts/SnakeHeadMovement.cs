using System.Collections.Generic;
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

    public GameObject snakeBody;
    protected List<Transform> snakePositionsList;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        snakePositionsList = new List<Transform>();
        snakePositionsList.Add(this.transform);
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
            for (int i = snakePositionsList.Count - 1; i > 0; i--)
            {
                snakePositionsList[i].position = snakePositionsList[i - 1].position;
            }
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


    public void Grow()
    {
        GameObject body = Instantiate(snakeBody, BodyInstantiationPosition(), Quaternion.identity);

        snakePositionsList.Add(body.transform);
    }

    public Vector2 BodyInstantiationPosition()
    {
        if (direction == Vector2.up)
        {
            return new Vector2(transform.position.x, transform.position.y - 1);
        }
        if (direction == Vector2.down)
        {
            return new Vector2(transform.position.x, transform.position.y + 1);

        }
        if (direction == Vector2.right)
        {
            return new Vector2(transform.position.x - 1, transform.position.y);
        }
        if (direction == Vector2.left)
        {
            return new Vector2(transform.position.x + 1, transform.position.y);
        }
        return Vector2.zero;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player Died");
        }
    }

}
