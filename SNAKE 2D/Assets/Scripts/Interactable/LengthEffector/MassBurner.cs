using UnityEngine;

public class MassBurner : Interactable
{
    public int shrinkLength;
    bool isVissible = false;
    void Start()
    {
        timer = respawnTime;
        HideItem();
        scorePoints *= shrinkLength;
    }
    protected override void Update()
    {
        if (Player1.Instance.GetSnakeLength() > 5)
        {
            timer -= Time.deltaTime;
        }
        if (Player1.Instance.GetSnakeLength() > 5 && timer <= 0)
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

        }


    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<Player1>() != null)
        {
            for (int i = 0; i < shrinkLength; i++)
            {
                collision.GetComponent<Player1>().Shrink();
                collision.GetComponent<Player1>().DecreaseScore(scorePoints);
                HideItem();
            }
        }

        if (collision.GetComponent<Player2>() != null)
        {
            for (int i = 0; i < shrinkLength; i++)
            {
                collision.GetComponent<Player2>().Shrink();
                collision.GetComponent<Player2>().DecreaseScore(scorePoints);
                HideItem();
            }
        }

    }
}
