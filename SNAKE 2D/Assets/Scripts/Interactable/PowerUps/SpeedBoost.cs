using UnityEngine;

public class SpeedBoost : PowerUps
{

    public float boostSpeed;


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
            SnakeHeadMovement.Instance.ResetMoveRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeHeadMovement>() != null)
        {
            powerTimer = powerWearOffTime;
            collision.GetComponent<SnakeHeadMovement>().moveRate = boostSpeed;
            HideItem();
        }
    }
}
