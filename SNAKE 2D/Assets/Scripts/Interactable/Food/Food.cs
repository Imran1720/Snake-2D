using UnityEngine;

public class Food : Interactable
{

    private void Start()
    {
        SpawnItem();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySFX(Sounds.Food);
        if (collision.gameObject.GetComponent<Player1>() != null)
        {
            collision.gameObject.GetComponent<Player1>().Grow();
            collision.GetComponent<Player1>().IncreaseScore(scorePoints);
            timer = respawnTime;
            SpawnItem();
        }

        if (collision.gameObject.GetComponent<Player2>() != null)
        {
            collision.gameObject.GetComponent<Player2>().Grow();
            collision.GetComponent<Player2>().IncreaseScore(scorePoints);
            timer = respawnTime;
            SpawnItem();
        }
    }
}
