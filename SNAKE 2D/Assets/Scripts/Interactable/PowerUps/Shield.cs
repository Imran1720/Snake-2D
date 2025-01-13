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

            SnakeHeadMovement.Instance.DeactivateShield();

        }
    }

    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.GetComponent<SnakeHeadMovement>() != null)
        {
            powerTimer = powerWearOffTime;
            collision.GetComponent<SnakeHeadMovement>().ActivateShield();
            HideItem();
        }
    }
}
