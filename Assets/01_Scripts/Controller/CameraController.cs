using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector2 turn;
    [SerializeField] private float sensitivity = .5f;
    [SerializeField] float moveSpeed = 1f;

    enum CameraPositions
    {
        Idle,
        Couch,
        Table,
        Bookshelf
    }

    enum CameraState
    {
        Moving,
        Stay
    }

    private CameraPositions _position = CameraPositions.Idle;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        switch (_position)
        {
            case CameraPositions.Idle:
                RotateCamera();
                MoveCamera();
                break;

            case CameraPositions.Couch:
                RotateCamera();
                break;
            
            case CameraPositions.Table:
                Cursor.lockState = CursorLockMode.Confined;
                break;

            case CameraPositions.Bookshelf:
                Cursor.lockState = CursorLockMode.Confined;
                break;
        }
    }

    private void RotateCamera()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;
        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
    }

    private void MoveCamera()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(h, 0, v).normalized * Time.deltaTime * moveSpeed);
    }
}
