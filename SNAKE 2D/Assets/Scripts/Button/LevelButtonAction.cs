using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButtonAction : MonoBehaviour
{
    /// <summary>
    ///Class for the buttons present in Level UI to navigate to Lobby, restart level
    ///and also to pause and resume game
    /// </summary>

    Button button;
    public ButtonActionsList action;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Action);
    }

    //This method takes in an action assiged to button and using swith performs that action Based on the level
    public void Action()
    {
        switch (action)
        {
            case ButtonActionsList.PauseGame:
                //Pause the Game
                SoundManager.instance.PlaySFX(Sounds.ButtonClick);
                if (GameManager.instance != null)
                {
                    //This gets executed when you are in Single Player mode
                    GameManager.instance.Pause();
                }
                else
                {
                    //This gets executed when you are in Two Player mode
                    CoopGameManager.instance.Pause();
                }
                break;
            case ButtonActionsList.Resume:
                SoundManager.instance.PlaySFX(Sounds.ButtonClick);

                if (GameManager.instance != null)
                {
                    //This gets executed when you are in Single Player mode
                    GameManager.instance.ShowHUD();
                }
                else
                {
                    //This gets executed when you are in Two Player mode
                    CoopGameManager.instance.ShowHUD();
                }
                break;
            case ButtonActionsList.Restart:
                //OnClick Restarts the level
                LevelManager.Instance.RestartLevel();
                break;
            case ButtonActionsList.Menu:
                //OnClick Loads the lobby
                LevelManager.Instance.LoadLevel((int)Levels.Menu);
                break;
        }
    }
}
