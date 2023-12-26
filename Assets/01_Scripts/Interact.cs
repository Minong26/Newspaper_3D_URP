using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject interactArea;
    public GameObject interactListPanel;

    private UIManager UI;

    private void Start()
    {
        
    }

    private void Update()
    {
        InteractAreaControl();
    }

    private void InteractAreaControl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3f))
        {
            //Debug.Log(hit.point);
            interactArea.transform.position = hit.point;
        }
        //else
            //interactArea.transform.position = Camera.main.transform.localposition + new Vector3(0, 0, 2f);
    }

    private void InteractPanel(GameObject interactObj)
    {
        
    }
}
