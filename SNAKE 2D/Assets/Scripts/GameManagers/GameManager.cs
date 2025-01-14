using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// GameManager for Single player mode 
    /// It handles following actions
    /// Updating Level UI
    /// GAMEOVER MENU -> Showing Gameover which shows which player won
    /// PAUSE MENU    -> poping Pause menu onclick
    /// SHOW HUD      -> Showing HUD when resume
    /// </summary>
    public static GameManager instance;
    [Header("Pannels Info")]
    public GameObject hudPannel, gameOverPannel, pausePannel;
    [Header("UI Texts")]
    public TextMeshProUGUI score, snakeLength;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        UpdatePlayerData();
    }

    //Showing GameOver screen, Called when Snake bite itself
    public void GameOver()
    {
        Time.timeScale = 0f;
        hudPannel.SetActive(false);
        gameOverPannel.SetActive(true);
    }

    //Pause the Game
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePannel.SetActive(true);
        hudPannel.SetActive(false);
    }

    //Called When Resume is Pressed
    public void ShowHUD()
    {
        Time.timeScale = 1f;
        pausePannel.SetActive(false);
        hudPannel.SetActive(true);
    }

    //Method to Update Player  Info
    public void UpdatePlayerData()
    {
        score.text = "" + Player1.Instance.score;
        snakeLength.text = "Snake : " + Player1.Instance.GetSnakeLength();
    }


}
