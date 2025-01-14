using UnityEngine;

public class PowerUps : Interactable
{
    public bool isVissible = false;

    public float powerWearOffTime;
    protected float powerTimer;

    private void Start()
    {
        timer = respawnTime;
        HideItem();
    }

    protected override void Update()
    {
        timer -= Time.deltaTime;
        powerTimer -= Time.deltaTime;
        PowerRespawn();

    }

    public void PowerRespawn()
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
    }

    public virtual void PowerWearOff()
    {

    }
}
