using UnityEngine;

public class PowerUps : Interactable
{
    public bool isVissible = false;

    public float powerWearOffTime;
    protected float powerTimer;


    protected override void Update()
    {
        timer -= Time.deltaTime;
        powerTimer -= Time.deltaTime;
        PowerRespawn();
        PowerWearOff();
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
            timer = respawnTime;
        }
    }

    public virtual void PowerWearOff()
    {
        if ((powerTimer <= 0))
        {
            powerTimer = powerWearOffTime;
        }
    }
}
