using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject hudPannel, gameOverPannel, pausePannel;
    public TextMeshProUGUI score, snakeLength;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Debug.Log(Player2.Instance == null);

        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        UpdateScore();
        UpdateLength();
    }
    public void GameOver()
    {
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

    public void UpdateScore()
    {

        score.text = "" + Player1.Instance.score;
    }

    public void UpdateLength()
    {
        snakeLength.text = "Snake : " + Player1.Instance.GetSnakeLength();
    }


}
