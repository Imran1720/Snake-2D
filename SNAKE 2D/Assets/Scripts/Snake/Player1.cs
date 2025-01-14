using UnityEngine;

public class Player1 : SnakeMovement
{

    static Player1 instance;
    public static Player1 Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
        direction = Vector2.up;
    }

    protected override void Update()
    {
        base.Update();

        PlayerInput();
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.W) && !BodyAt(transform.position.x, transform.position.y + 1))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S) && !BodyAt(transform.position.x, transform.position.y - 1))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D) && !BodyAt(transform.position.x + 1, transform.position.y))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A) && !BodyAt(transform.position.x - 1, transform.position.y))
        {
            direction = Vector2.left;
        }
    }

    public override void IncreaseScore(int value)
    {
        score += value * ScoreBooster.Instance.player1ScoreBoost;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player2>() != null)
        {
            if (collision.gameObject.GetComponent<Player2>().GetSnakeLength() > GetSnakeLength())
            {
                CoopGameManager.instance.GameOver("Player2");
            }
            else
            {
                CoopGameManager.instance.GameOver("Player1");
            }
        }
    }
}

