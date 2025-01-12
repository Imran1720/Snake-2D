using UnityEngine;

public class MassBurner : Interactable
{
    public int shrinkLength;
    void Start()
    {
        timer = respawnTime;
        HideItem();
        scorePoints *= shrinkLength;
    }
    protected override void Update()
    {
        if (SnakeHeadMovement.Instance.GetSnakeLength() > 5 && timer <= 0)
        {
            SpawnItem();
            timer = respawnTime;
        }

        timer -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<SnakeHeadMovement>() != null)
        {
            for (int i = 0; i < shrinkLength; i++)
            {
                collision.GetComponent<SnakeHeadMovement>().Shrink();
                collision.GetComponent<SnakeHeadMovement>().DecreaseScore(scorePoints);

                HideItem();
            }
        }
    }
}
