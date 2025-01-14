using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButtonAction : MonoBehaviour
{
    Button button;
    public ButtonActionsList action;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Action);
    }

    public void Action()
    {
        switch (action)
        {
            case ButtonActionsList.PauseGame:
                SoundManager.instance.PlaySFX(Sounds.ButtonClick);
                if (GameManager.instance != null)
                {
                    GameManager.instance.Pause();
                }
                else
                {
                    CoopGameManager.instance.Pause();
                }
                break;
            case ButtonActionsList.Resume:
                SoundManager.instance.PlaySFX(Sounds.ButtonClick);

                if (GameManager.instance != null)
                {
                    GameManager.instance.ShowHUD();
                }
                else
                {
                    CoopGameManager.instance.ShowHUD();
                }
                break;
            case ButtonActionsList.Restart:
                LevelManager.Instance.RestartLevel();
                break;
            case ButtonActionsList.Menu:
                SoundManager.instance.PlaySFX(Sounds.ButtonClick);
                LevelManager.Instance.LoadLevel((int)Levels.Menu);
                break;
        }
    }
}
