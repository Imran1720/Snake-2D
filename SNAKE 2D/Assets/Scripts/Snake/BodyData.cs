using UnityEngine;
using UnityEngine.SceneManagement;

public class BodyData : MonoBehaviour
{
    public GameObject snakeHead;
    public GameObject shield;


    // Update is called once per frame
    void Update()
    {
        if ((snakeHead.GetComponent<Player1>() != null && snakeHead.GetComponent<Player1>().immune) ||
            (snakeHead.GetComponent<Player2>() != null && snakeHead.GetComponent<Player2>().immune))
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            {
                if (collision.GetComponent<Player2>() && !Player1.Instance.immune)
                {
                    CoopGameManager.instance.GameOver("Player2");
                    //Debug.Log("PLayer 2 detected!!");
                }
                if (collision.GetComponent<Player1>() && !Player2.Instance.immune)
                {

                    CoopGameManager.instance.GameOver("Player1");
                    // Debug.Log("PLayer 1 detected!!");
                }
            }
        }
        else
        {
            if (collision.GetComponent<Player1>() && !Player1.Instance.immune)
            {
                GameManager.instance.GameOver();
            }
        }
    }

}
