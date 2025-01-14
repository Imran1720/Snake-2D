using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance { get { return instance; } }




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadLevel(int index)
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        SceneManager.LoadScene(index);
    }

    public void RestartLevel()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        SoundManager.instance.PlaySFX(Sounds.ButtonClick);
        Application.Quit();
    }
}
