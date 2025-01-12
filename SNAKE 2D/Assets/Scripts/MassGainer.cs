using UnityEngine;

public class MassGainer : Interactable
{
    public int lengthToIncrease;

    private void Start()
    {
        timer = respawnTime;
        scorePoints *= lengthToIncrease;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeHeadMovement>() != null)
        {
            HideItem();
            for (int i = 0; i < lengthToIncrease; i++)
            {
                collision.GetComponent<SnakeHeadMovement>().Grow();
                collision.GetComponent<SnakeHeadMovement>().IncreaseScore(scorePoints);
                HideItem();
            }
        }
    }
}
