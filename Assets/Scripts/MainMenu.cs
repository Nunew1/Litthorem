using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Gameplay()
    {
        SceneManager.LoadScene("Maze");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MainMenuu()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void Quit()
    {
        Application.Quit();
    }
}
