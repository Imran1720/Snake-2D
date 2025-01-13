using UnityEngine;

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
}
