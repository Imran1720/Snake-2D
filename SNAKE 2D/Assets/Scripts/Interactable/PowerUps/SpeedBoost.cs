using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedBoost : PowerUps
{
    public float boostSpeed;
    protected override void Update()
    {
        base.Update();
        PowerWearOff();
    }

    //Method that removes the speed boost effect
    public override void PowerWearOff()
    {
        if (powerTimer <= 0)
        {
            powerTimer = powerWearOffTime;
            Player1.Instance.ResetMoveRate();
            if (SceneManager.GetActiveScene().buildIndex == 2)
                Player2.Instance.ResetMoveRate();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.instance.PlaySFX(Sounds.PowerUp);
        //Activating the speed buff for Player1
        if (collision.GetComponent<Player1>() != null)
        {
            powerTimer = powerWearOffTime;
            //As the same class is used in single player mode and it does not have player2
            //this condition avoids exception related to Player2
            if (Player2.Instance != null)
            {
                Player2.Instance.ResetMoveRate();
            }
            collision.GetComponent<Player1>().moveRate = boostSpeed;
            HideItem();
        }
        //Activating the speed buff for Player2
        if (collision.GetComponent<Player2>() != null)
        {
            powerTimer = powerWearOffTime;
            Player1.Instance.ResetMoveRate();
            collision.GetComponent<Player2>().moveRate = boostSpeed;
            HideItem();
        }

    }
}
