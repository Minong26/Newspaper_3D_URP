using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Lobby");
    }

    void Start()
    {
        GameObject gameManager = GameObject.Find("@Managers");
        if (gameManager == null)
        {
            gameManager = new GameObject("@Managers");
            gameManager.AddComponent<GameManager>();
        }
        DontDestroyOnLoad(gameManager);
    }
}
