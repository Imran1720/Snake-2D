using UnityEngine;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{

    public Button quit, play, back;

    public GameObject lobby, Mode;
    void Start()
    {

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
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        lobby.SetActive(false);
        Mode.SetActive(true);
    }

    void Back()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        lobby.SetActive(true);
        Mode.SetActive(false);
    }
}
