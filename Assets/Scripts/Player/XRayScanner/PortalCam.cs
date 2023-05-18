using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCam : MonoBehaviour
{
    // Start is called before the first frame update

    PlayerController playerController;
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;
    void Start()
    {
        playerController = PlayerController.Instance;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (portal != null && otherPortal != null)
        {
            Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
            transform.position = portal.position + playerOffsetFromPortal;

            float angularDifferenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

            Quaternion portalRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenPortalRotations, Vector3.up);
            Vector3 newCameraDirection = portalRotationalDifference * playerCamera.forward;
            transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        }
    }
}
