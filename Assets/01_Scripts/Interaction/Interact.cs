using Cinemachine;
using TMPro;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public GameObject player;

    public GameObject interactablePopup;
    public TextMeshProUGUI interactableItemDescription;

    [Header("CameraPosition")]
    public Transform frontOfBookshelf;
    public Transform onTheCouch;
    public Transform onTheBed;

    private InputManager _input;
    private bool _playerWithCamera = true;
    private CursorController _cursor;

    private void Start()
    {
        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }
    
    private void Update()
    {
        InteractUIControl();
        InteractEvent();
    }

    private void InteractUIControl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(ray, out hit, 1f, layerMask))
        {
            interactablePopup.SetActive(true);
            if (hit.transform.name == "BookShelf02")
                interactableItemDescription.text = "지난 뉴스 읽기";
            else if (hit.transform.name == "Couch")
                interactableItemDescription.text = "소파에 앉기";
            else if (hit.transform.name == "Bed")
                interactableItemDescription.text = "잠자기";
        }
        else
        {
            interactablePopup.SetActive(false);
        }
    }

    private void InteractEvent()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction * 100, Color.red, 1.0f);

        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(ray, out hit, 1f, layerMask))
        {
            CinemachineVirtualCamera vcam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
            if (_playerWithCamera)
            {
                if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
                {
                    if (hit.transform.name == "Couch")
                    {
                        //_cursor.
                        vcam.Follow = onTheCouch;
                    }
                    else if (hit.transform.name == "Bed")
                    {
                        vcam.Follow = onTheBed;
                    }
                    else if (hit.transform.name == "BookShelf02")
                    {
                        vcam.Follow = frontOfBookshelf;
                    }
                    _playerWithCamera = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    vcam.Follow = player.transform;
                    _playerWithCamera = true;
                }
            }
        }
    }
}
