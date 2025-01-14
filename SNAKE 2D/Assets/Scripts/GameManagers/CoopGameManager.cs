using TMPro;
using UnityEngine;

public class CoopGameManager : MonoBehaviour
{
    /// <summary>
    /// GameManager for Co-op/ Two player mode 
    /// It handles following actions
    /// Updating Level UI
    /// GAMEOVER MENU -> Showing Gameover which shows which player won
    /// PAUSE MENU    -> poping Pause menu onclick
    /// SHOW HUD      -> Showing HUD when resume
    /// </summary>

    public static CoopGameManager instance;
    [Header("Pannels Info")]
    public GameObject hudPannel, gameOverPannel, pausePannel;

    [Header("Gameover Texts")]
    public GameObject player1WinText, player2WinText;

    [Header("UI Texts")]
    public TextMeshProUGUI player1Info, player2Info;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //ensuring that games time flow normally on restart
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        //Updating both Player data
        UpdatePlayer1Score();
        UpdatePlayer2Score();
    }

    //Showing GameOver screen and shows the text which player won 
    public void GameOver(string winner)
    {
        Time.timeScale = 0f;
        if (winner == "Player1")
        {
            player1WinText.SetActive(true);
            player2WinText.SetActive(false);
        }
        else
        {
            player1WinText.SetActive(false);
            player2WinText.SetActive(true);
        }
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

    //Method to Update Player 1 Info
    public void UpdatePlayer1Score()
    {
        player1Info.text = "Snake 1 : " + Player1.Instance.GetSnakeLength() + ", Score : " + Player1.Instance.score;
    }
    //Method to Update Player 2 Info
    public void UpdatePlayer2Score()
    {
        player2Info.text = "Snake 2 : " + Player2.Instance.GetSnakeLength() + ", Score : " + Player2.Instance.score;
    }



}
