using TMPro;
using UnityEngine;

public class Newspaper : MonoBehaviour
{
    public GameObject checkGameObjcet;

    private Vector2 mousePos;

    void Open()
    {

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Instantiate(checkGameObjcet, Input.mousePosition, nnQuaternion.EulerAngles(mousePos));
        }
    }

    private void NextPage()
    {

    }
}
