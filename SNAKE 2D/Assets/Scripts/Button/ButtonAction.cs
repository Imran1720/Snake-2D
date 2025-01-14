using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonAction : MonoBehaviour
{
    //This is class related to buttons that loads levels
    //used for buttons that loads "SINGLE PLAYER MODE" and "TWO PLAYER MODE"
    public Levels level;
    Button button;
    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }

    //Method used to load Level Based on Scene index
    void LoadLevel()
    {
        LevelManager.Instance.LoadLevel((int)level);
    }
}
