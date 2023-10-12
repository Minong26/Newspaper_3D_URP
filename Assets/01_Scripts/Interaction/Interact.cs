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

    [Header("CameraLookAt")]
    public Transform bookShelf02;
    public Transform table;
    public Transform loop;

    private InputManager _input;
    private CinemachineVirtualCamera vcam;
    private CinemachinePOVExtention vcamPov;
    private bool _playerWithCamera = true;
    private CursorController _cursor;
    private CinemachinePOVExtention cinePov;

    private Animator _animator;

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
        vcamPov = GameObject.Find("Virtual Camera").GetComponent<CinemachinePOVExtention>();
        _animator = GameObject.Find("Sleep").GetComponent<Animator>();
        _cursor = GameObject.Find("@Controllers").GetComponent<CursorController>();

        if (player == null)
        {
            player = GameObject.Find("Player");
        }
    }
    
    private void Update()
    {
        InteractUIControl();
        if (_cursor._sceneStatus == CursorController.SceneStatus.GamePlayingAround)
            InteractEvent();
    }

    private void InteractUIControl()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 cameraPos = Camera.main.transform.position;

        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Interactable");
        if (Physics.Raycast(ray, out hit, 2f, layerMask))
        {
            interactablePopup.SetActive(true);
            if (hit.transform.name == "Couch")
                interactableItemDescription.text = "의자에 앉기";
            else if (hit.transform.name == "Bed")
                interactableItemDescription.text = "잠자기";
            else if (hit.transform.name == "BookShelf02")
            {
                if (_interactWith == InteractWith.None)
                    interactableItemDescription.text = "지난 신문 찾기";
                else if (_interactWith == InteractWith.Bookshelf)
                    interactablePopup.SetActive(false);
            }
            else if (hit.transform.tag == "News")
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
                    if (hit.transform.name == "Couch")
                    {
                        vcam.Follow = onTheCouch;
                        vcam.LookAt = table;
                        vcam.AddCinemachineComponent<CinemachineHardLookAt>();
                        vcamPov.enabled = false;

                        _interactWith = InteractWith.Couch;
                    }
                    else if (hit.transform.name == "Bed")
                    {
                        vcam.Follow = onTheBed;
                        vcam.LookAt = loop;
                        vcam.AddCinemachineComponent<CinemachineHardLookAt>();
                        vcamPov.enabled = false;

                        _interactWith = InteractWith.Bed;
                    }
                    else if (hit.transform.name == "BookShelf02")
                    {
                        vcam.Follow = frontOfBookshelf;
                        vcam.LookAt = bookShelf02;
                        vcam.AddCinemachineComponent<CinemachineHardLookAt>();
                        vcamPov.enabled = false;

                        _interactWith = InteractWith.Bookshelf;
                    }
                }
                break;
            case InteractWith.Couch:
                _cursor._sceneStatus = CursorController.SceneStatus.GameFocused;

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
            case InteractWith.Bed:
                _cursor._sceneStatus = CursorController.SceneStatus.GameFocused;

                _animator.Play("GettingSleep");
                ExitInteract();

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
            case InteractWith.Bookshelf:
                _cursor._sceneStatus = CursorController.SceneStatus.GameFocused;

                if (Input.GetKeyDown(KeyCode.C))
                    ExitInteract();
                break;
        }
    }

    private void ExitInteract()
    {
        _cursor._sceneStatus = CursorController.SceneStatus.GamePlayingAround;
        _interactWith = InteractWith.None;

        vcam.Follow = player.transform.Find("CameraPosition");
        vcam.LookAt = null;
        vcam.AddCinemachineComponent<CinemachinePOV>();
        vcamPov.enabled = true;
    }
}
