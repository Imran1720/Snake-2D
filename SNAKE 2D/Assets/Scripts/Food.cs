using UnityEngine;

public class Food : Interactable
{

    private void Start()
    {
        SpawnItem();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<SnakeHeadMovement>() != null)
        {
            timer = respawnTime;
            SpawnItem();
        }
    }


}
