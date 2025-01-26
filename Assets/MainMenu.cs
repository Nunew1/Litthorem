using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
        Quit();
    }
}
