using TMPro;
using UnityEngine;

public class CoopGameManager : MonoBehaviour
{
    public static CoopGameManager instance;

    public GameObject hudPannel, gameOverPannel, pausePannel;
    public GameObject player1WinText, player2WinText;
    public TextMeshProUGUI player1Info, player2Info;

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
        UpdatePlayer1Score();
        UpdatePlayer2Score();
    }
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

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePannel.SetActive(true);
        hudPannel.SetActive(false);
    }

    public void ShowHUD()
    {
        Time.timeScale = 1f;
        pausePannel.SetActive(false);
        hudPannel.SetActive(true);
    }

    public void UpdatePlayer1Score()
    {
        player1Info.text = "Snake 1 : " + Player1.Instance.GetSnakeLength() + ", Score : " + Player1.Instance.score;
    }
    public void UpdatePlayer2Score()
    {
        player2Info.text = "Snake 2 : " + Player2.Instance.GetSnakeLength() + ", Score : " + Player2.Instance.score;
    }



}
