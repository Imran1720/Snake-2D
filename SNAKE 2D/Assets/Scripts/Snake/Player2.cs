using UnityEngine;

public class Player2 : SnakeMovement
{

    private static Player2 instance;
    public static Player2 Instance { get { return instance; } }

    private void Awake()
    {
        instance = this;
        direction = Vector2.down;
    }

    protected override void Update()
    {
        base.Update();
        PlayerInput();

    }


    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !BodyAt(transform.position.x, transform.position.y + 1))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && !BodyAt(transform.position.x, transform.position.y - 1))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && !BodyAt(transform.position.x + 1, transform.position.y))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && !BodyAt(transform.position.x - 1, transform.position.y))
        {
            direction = Vector2.left;
        }
    }

    public override void IncreaseScore(int value)
    {
        score += value * ScoreBooster.Instance.player2ScoreBoost;

    }




}
