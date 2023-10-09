using UnityEngine;

public class Cases : MonoBehaviour
{
    private static Managers s_Instance;
    static Managers Instance { get { Init(); return s_Instance; } }

    private InputManager _input = new InputManager();
    public static InputManager Input { get { return Instance._input; } }

    private UIManager _ui = new UIManager();
    public static UIManager UI { get { return Instance._ui; } }

    public static Managers GetInstance()
    {
        Init();
        return Instance;
    }

    private static void Init()
    {
        GameObject go = GameObject.Find("@Managers");
        if (go == null)
        {
            go = new GameObject() { name = "@Managers" };
            go.AddComponent<Managers>();
        }
        DontDestroyOnLoad(go);
        s_Instance = go.GetComponent<Managers>();
    }
}
