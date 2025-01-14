using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    protected Vector2 direction;
    [SerializeField]
    protected Vector2 snakeBodyPosition;
    [Header("Movement Info")]
    public float moveRate, defaultMoveRate;
    public float timer;


    [Header("Snake Body Info")]
    protected List<Transform> snakePositionsList;
    public GameObject snakeBody;

    [Header("Shield Info")]
    public GameObject shield;
    public bool immune;

    [Header("UI Info")]
    public int score;


    private void Start()
    {
        snakePositionsList = new List<Transform>();
        snakePositionsList.Add(this.transform);


        moveRate = defaultMoveRate;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        timer -= Time.deltaTime;
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
        body.GetComponent<BodyData>().snakeHead = this.gameObject;
        snakePositionsList.Add(body.transform);
    }

    public void Shrink()
    {
        if (snakePositionsList.Count > 1)
        {
            Destroy(snakePositionsList[snakePositionsList.Count - 1].gameObject);
            snakePositionsList.RemoveAt(snakePositionsList.Count - 1);
        }
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

    public bool BodyAt(float x, float y)
    {
        Vector3 position = new Vector3(x, y);
        for (int i = 1; i < snakePositionsList.Count; i++)
        {
            if (position == snakePositionsList[i].position)
            {
                return true;
            }
        }
        return false;
    }

    public int GetSnakeLength()
    {
        return snakePositionsList.Count;
    }
    public virtual void IncreaseScore(int value)
    {
        score += value;
    }
    public void DecreaseScore(int value)
    {
        score -= value;
        if (score < 0)
        {
            score = 0;
        }

    }

    public void ResetMoveRate()
    {
        moveRate = defaultMoveRate;
    }

    public void ActivateShield()
    {
        immune = true;
        shield.SetActive(true);
    }
    public void DeactivateShield()
    {
        immune = false;
        shield.SetActive(false);
    }


}
