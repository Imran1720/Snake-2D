using UnityEngine;
using UnityEngine.UI;

public class MenuActions : MonoBehaviour
{

    /// <summary>
    /// This class is related to main menu Buttons Play,Quit and Back 
    /// Play-Hides lobby pannel and shows Levels
    /// Quit-Quits Application
    /// Back-Hides levels and shows Lobby
    /// </summary>
    public Button quit, play, back;

    public GameObject lobby, Mode;
    void Start()
    {
        //Binds the three buttons with respective actions
        quit.onClick.AddListener(Quit);
        play.onClick.AddListener(Play);
        back.onClick.AddListener(Back);
    }

    //Quit the Game
    void Quit()
    {
        LevelManager.Instance.Quit();
    }

    //Shows Levels and hides Lobby
    void Play()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        lobby.SetActive(false);
        Mode.SetActive(true);
    }

    //Shows Lobby and hides Levesl
    void Back()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        lobby.SetActive(true);
        Mode.SetActive(false);
    }
}
