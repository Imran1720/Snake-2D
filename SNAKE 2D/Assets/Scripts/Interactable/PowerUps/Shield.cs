public class Shield : PowerUps
{


    protected override void Update()
    {
        base.Update();
        PowerWearOff();
    }


    public override void PowerWearOff()
    {
        if (powerTimer <= 0)
        {
            powerTimer = powerWearOffTime;
            Player1.Instance.DeactivateShield();
            Player2.Instance.DeactivateShield();

        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<Player1>() != null)
        {
            powerTimer = powerWearOffTime;
            collision.GetComponent<Player1>().ActivateShield();
            Player2.Instance.DeactivateShield();
            HideItem();
        }

        if (collision.GetComponent<Player2>() != null)
        {
            powerTimer = powerWearOffTime;
            collision.GetComponent<Player2>().ActivateShield();
            Player1.Instance.DeactivateShield();
            HideItem();
        }

    }
}
