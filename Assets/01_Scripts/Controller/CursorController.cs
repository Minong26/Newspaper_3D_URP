using UnityEngine;

public class CursorController : MonoBehaviour
{
    public enum SceneStatus
    {
        GamePlayingAround,
        GameFocused,
        GamePaused
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public SceneStatus _sceneStatus = SceneStatus.GamePlayingAround;
    private void Update()
    {
        switch (_sceneStatus)
        {
            case SceneStatus.GamePlayingAround:
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                break;
            case SceneStatus.GameFocused:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;
            case SceneStatus.GamePaused:
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                break;
        }
    }
}
