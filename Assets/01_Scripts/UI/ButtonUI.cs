using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLobbyScene()
    {
        SceneManager.LoadScene("Lobby");
    }
}
