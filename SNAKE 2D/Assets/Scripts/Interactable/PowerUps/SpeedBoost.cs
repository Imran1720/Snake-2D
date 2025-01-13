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
            Player1.Instance.ResetMoveRate();
            Player2.Instance.ResetMoveRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player1>() != null)
        {
            powerTimer = powerWearOffTime;
            Player2.Instance.ResetMoveRate();
            collision.GetComponent<Player1>().moveRate = boostSpeed;
            HideItem();
        }
        if (collision.GetComponent<Player2>() != null)
        {
            powerTimer = powerWearOffTime;
            Player1.Instance.ResetMoveRate();
            collision.GetComponent<Player2>().moveRate = boostSpeed;
            HideItem();
        }

    }
}
