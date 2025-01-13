using UnityEngine;

public class ScoreBooster : PowerUps
{
    private static ScoreBooster instance;
    public static ScoreBooster Instance { get { return instance; } }
    public int defaultscale, scoreBoost;
    public int player1ScoreBoost, player2ScoreBoost;
    private void Awake()
    {
        instance = this;
    }

    protected override void Update()
    {
        base.Update();
        PowerWearOff();
    }

    public override void PowerWearOff()
    {
        if (powerTimer <= 0)
        {
            player1ScoreBoost = defaultscale;
            player2ScoreBoost = defaultscale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player1>() != null)
        {
            powerTimer = powerWearOffTime;
            player1ScoreBoost = scoreBoost;
            HideItem();
        }
        if (collision.GetComponent<Player2>() != null)
        {
            powerTimer = powerWearOffTime;
            player2ScoreBoost = scoreBoost;
            HideItem();
        }

    }
}