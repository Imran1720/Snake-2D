using UnityEngine;

public class MassGainer : Interactable
{
    public int lengthToIncrease;
    bool isVissible = false;
    private void Start()
    {
        timer = respawnTime;
        HideItem();
        scorePoints *= lengthToIncrease;
    }

    protected override void Update()
    {
        if (timer <= 0)
        {
            if (!isVissible)
            {
                isVissible = true;
                SpawnItem();
            }
            else
            {
                isVissible = false;
                HideItem();
            }
            timer = respawnTime;
        }

        timer -= Time.deltaTime;

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
