using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject pauseUI;
    public bool pauseUIOpened = false;

    private Stack<GameObject> _uiStack = new Stack<GameObject>();

    private GameManager _gameManager;

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

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pauseUIOpened)
            {
                pauseUI.SetActive(true);
                _uiStack.Push(pauseUI);
                pauseUIOpened = true;
            }
            else
            {
                CloseCurrentUI();
            }
        }
    }

    public void UpdateUIStack()
    {
        _uiStack.Push(this.gameObject);
    }

    private void CloseCurrentUI()
    {
        if (_uiStack.Count == 0)
        {
            pauseUIOpened = false;
            return;
        }

        GameObject closeUI = _uiStack.Pop();
        closeUI.SetActive(false);
        closeUI = null;
    }

    public void InteractUIControl()
    {
        
    }
}
