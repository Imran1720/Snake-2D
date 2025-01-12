using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Vector2 minSpawnCoordinate;
    public Vector2 maxSpawnCoordinate;

    public float respawnTime;
    protected float timer;
    public int scorePoints;
    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SpawnItem();
            timer = respawnTime;
        }
    }
    public void SpawnItem()
    {
        float x = Random.Range(minSpawnCoordinate.x, maxSpawnCoordinate.x);
        float y = Random.Range(minSpawnCoordinate.y, maxSpawnCoordinate.y);

        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    public void HideItem()
    {
        this.transform.position = new Vector2(100, 100);
    }
}
