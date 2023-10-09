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
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(ray, out hit, 2.5f, layerMask))
        {
            interactArea.transform.position = hit.point;
        }
        else
        {
            interactArea.transform.position = new Vector3(cameraPos.x, cameraPos.y, cameraPos.z);
        }
    }

    private void InteractPanel(GameObject interactObj)
    {
        
    }
}
