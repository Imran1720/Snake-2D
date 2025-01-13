using UnityEngine;

public class BodyData : MonoBehaviour
{
    public GameObject snakeHead;
    public GameObject shield;


    // Update is called once per frame
    void Update()
    {
        if (snakeHead.GetComponent<SnakeHeadMovement>() != null && snakeHead.GetComponent<SnakeHeadMovement>().immune)
        {
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }
}
