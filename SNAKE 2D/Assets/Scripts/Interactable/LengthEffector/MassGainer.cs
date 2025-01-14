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
        }

        timer -= Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySFX(Sounds.Food);
        if (collision.GetComponent<Player1>() != null)
        {
            HideItem();
            for (int i = 0; i < lengthToIncrease; i++)
            {
                collision.GetComponent<Player1>().Grow();
                collision.GetComponent<Player1>().IncreaseScore(scorePoints);
                HideItem();
            }
        }
        if (collision.GetComponent<Player2>() != null)
        {
            HideItem();
            for (int i = 0; i < lengthToIncrease; i++)
            {
                collision.GetComponent<Player2>().Grow();
                collision.GetComponent<Player2>().IncreaseScore(scorePoints);
                HideItem();
            }
        }

    }
}
