using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUI : UIManager
{
    public void ApplicationQuit()
    {
        Application.Quit();
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(1);
    }
}
