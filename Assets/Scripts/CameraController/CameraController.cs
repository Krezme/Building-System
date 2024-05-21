using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    /* public float speed;
    public float rotationSpeed;
    public float rotationVelocity;
    public float verticalVelocity;

    private const float threshold = 0.01f;

    private float cinemachineTargetPitch;

    public const float topClamp = 89.0f;
    public const float bottomClamp = -89.0f;

    public GameObject CinemachineCameraTarget;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        // if there is an input
        if (CameraInputs.instance.look.sqrMagnitude >= threshold)
        {
            //Don't multiply mouse input by Time.deltaTime
            float deltaTimeMultiplier =  1.0f;
            
            cinemachineTargetPitch += CameraInputs.instance.look.y * rotationSpeed * deltaTimeMultiplier;
            rotationVelocity = CameraInputs.instance.look.x * rotationSpeed * deltaTimeMultiplier;

            // clamp our pitch rotation
            cinemachineTargetPitch = ClampAngle(cinemachineTargetPitch, bottomClamp, topClamp);

            // Update Cinemachine camera target pitch
            CinemachineCameraTarget.transform.localRotation = Quaternion.Euler(cinemachineTargetPitch, 0.0f, 0.0f);

            // rotate the player left and right
            transform.Rotate(Vector3.up * rotationVelocity);
        }
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    } */
}
