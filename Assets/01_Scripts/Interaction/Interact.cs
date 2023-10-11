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
    private CinemachineVirtualCamera vcam;
    private bool _playerWithCamera = true;
    private CursorController _cursor;
    private CinemachinePOVExtention cinePov;

    private enum InteractWith
    {
        None,
        Couch,
        Bed,
        Bookshelf
    }

    private void Start()
    {
        vcam = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();

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
        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(ray, out hit, 1f, layerMask))
        {
            interactablePopup.SetActive(true);
            if (hit.transform.name == "Couch")
                interactableItemDescription.text = "의자에 앉기";
            else if (hit.transform.name == "Bed")
                interactableItemDescription.text = "잠자기";
            else if (hit.transform.name == "BookShelf02")
                interactableItemDescription.text = "지난 신문 찾기";
            else if (hit.transform.tag == "신문")
                interactableItemDescription.text = "신문 읽기";
        }
        else
        {
            interactablePopup.SetActive(false); interactableItemDescription.text = null;
        }
    }

    private InteractWith _interactWith = InteractWith.None;
    private void InteractEvent()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");

        switch (_interactWith)
        {
            case InteractWith.None:
                if (Physics.Raycast(ray, out hit, 1f, layerMask) && Input.GetKeyDown(KeyCode.F))
                {
                    Debug.Log("NONEEEEEEEEEEEEEEEEEEEEE");
                    if (hit.transform.name == "Couch")
                    {
                        vcam.Follow = onTheCouch;
                        _interactWith = InteractWith.Couch;
                    }
                    else if (hit.transform.name == "Bed")
                    {
                        vcam.Follow = onTheBed;
                        _interactWith = InteractWith.Bed;
                    }
                    else if (hit.transform.name == "BookShelf02")
                    {
                        vcam.Follow = frontOfBookshelf;
                        _interactWith = InteractWith.Bookshelf;
                    }
                }
                break;
            case InteractWith.Couch:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
            case InteractWith.Bed:
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
            case InteractWith.Bookshelf:
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
        }
    }

    private void ExitInteract()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _interactWith = InteractWith.None;

        vcam.Follow = player.transform.Find("CameraPosition");
    }
}
