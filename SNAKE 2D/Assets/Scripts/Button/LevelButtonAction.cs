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
                GameManager.instance.Pause();
                break;
            case ButtonActionsList.Resume:
                GameManager.instance.ShowHUD();
                break;
            case ButtonActionsList.Restart:
                LevelManager.Instance.RestartLevel();
                break;
            case ButtonActionsList.Menu:
                LevelManager.Instance.LoadLevel((int)Levels.Menu);
                break;
        }
    }
}
