using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject interactPanel;
    public GameObject interactItem;

    private enum UI
    {
        CurrentUI,
        ExUI
    }

    private void Start()
    {
        GameObject uiManager = GameObject.Find("@Managers");
        if (uiManager == null)
        {
            uiManager = new GameObject("@Managers");
            uiManager.AddComponent<UIManager>();
        }
        DontDestroyOnLoad(uiManager);
    }

    private void CloseAllUI()
    {

    }

    private void CloseCurrentUI()
    {

    }

    public void InteractUIControl()
    {
        
    }
}
