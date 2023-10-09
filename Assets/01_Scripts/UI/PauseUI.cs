using UnityEngine;

public class PauseUI : UIManager
{
    public GameObject pauseCanvas;
    public GameObject saveLoadCanvas;

    void Start()
    {
        pauseCanvas = GameObject.Find("PauseUI");
        saveLoadCanvas = GameObject.Find("SaveLoadUI");

        pauseCanvas.SetActive(false);
        saveLoadCanvas.SetActive(false);
    }

    void Update()
    {
        if (_status == uiStatus.Popup && Input.GetKeyDown(KeyCode.Escape))
        {
            ClearUI();
        }
    }
}
