using UnityEngine;
using Cinemachine;

public class CinemachinePOVExtention : CinemachineExtension
{
    [SerializeField]
    private float horizontalSpeed = 10f;
    [SerializeField]
    private float verticalSpeed = 10f;
    [SerializeField]
    private float clampAngle = 80f;

    private InputManager _inputManager;
    private Vector3 startingRotation;

    protected override void Awake()
    {
        _inputManager = InputManager.Instance;
        if (startingRotation == null)
            startingRotation = transform.localRotation.eulerAngles;
        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if (stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = _inputManager.GetMouseDelta();
                //startingRotation.x == Rotateion axis is x, it means rotate up and down
                startingRotation.x += deltaInput.x * verticalSpeed * Time.deltaTime;
                //startingRotation.y == Rotateion axis is y, it means rotate left and right
                startingRotation.y += deltaInput.y * horizontalSpeed * Time.deltaTime;
                startingRotation.y = Mathf.Clamp(startingRotation.y, -clampAngle, clampAngle);
                
                state.RawOrientation = Quaternion.Euler(-startingRotation.y, startingRotation.x, 0f);
            }
        }
    }
}
