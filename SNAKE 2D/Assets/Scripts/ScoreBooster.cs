using UnityEngine;

public class ScoreBooster : PowerUps
{
    private static ScoreBooster instance;
    public static ScoreBooster Instance { get { return instance; } }
    public int scoreScale, defaultscale, scoreBoost;

    private void Awake()
    {
        instance = this;
    }

    public override void PowerWearOff()
    {
        if (powerTimer <= 0)
        {
            scoreScale = defaultscale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<SnakeHeadMovement>() != null)
        {
            powerTimer = powerWearOffTime;
            scoreScale = scoreBoost;
            HideItem();
        }
    }
}