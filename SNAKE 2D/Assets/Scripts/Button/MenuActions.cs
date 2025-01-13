using UnityEngine;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{

    public Button quit, play, back;

    public GameObject lobby, Mode;
    void Start()
    {
        Back();
        quit.onClick.AddListener(Quit);
        play.onClick.AddListener(Play);
        back.onClick.AddListener(Back);
    }

    void Quit()
    {
        LevelManager.Instance.Quit();
    }
    void Play()
    {
        lobby.SetActive(false);
        Mode.SetActive(true);
    }

    void Back()
    {
        lobby.SetActive(true);
        Mode.SetActive(false);

    }
}
