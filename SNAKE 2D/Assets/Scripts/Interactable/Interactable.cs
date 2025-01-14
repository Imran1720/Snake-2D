using UnityEngine;

public class Interactable : MonoBehaviour
{

    /// <summary>
    /// Base class for all the Interactable
    /// This class has Common method used across various interactables 
    /// making Code resueability
    /// </summary>
    [Header("Spawn Range")]
    public Vector2 minSpawnCoordinate;
    public Vector2 maxSpawnCoordinate;

    [Header("Interactable Info")]
    public float respawnTime, fieldTime;
    protected float timer;
    public int scorePoints;
    public float rarity;


    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            timer = respawnTime;
            SpawnItem();
        }
    }

    //Spawn Interactables which has (rarity%) chance of spawning on field
    public void SpawnItem()
    {
        if (SpawnChance())
        {
            float x = Random.Range(minSpawnCoordinate.x, maxSpawnCoordinate.x);
            float y = Random.Range(minSpawnCoordinate.y, maxSpawnCoordinate.y);
            timer = fieldTime;
            this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
        }
    }

    //After Interactables are spawn on field they get hidden for some time before spawning again
    public void HideItem()
    {
        timer = respawnTime;
        this.transform.position = new Vector2(100, 100);
    }

    //Method that determine whether the interactable spawns, which depends on its rearity
    public bool SpawnChance()
    {
        int randomNumber = Random.Range(0, 100);
        if (randomNumber <= rarity)
        {
            return true;
        }
        return false;
    }
}
