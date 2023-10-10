using UnityEngine;


public class GameManager : MonoBehaviour
{
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
