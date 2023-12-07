using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GotoGame()
    {
        SceneManager.LoadScene("gameScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
