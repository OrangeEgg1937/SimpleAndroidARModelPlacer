using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class AR_Camera_Setting : MonoBehaviour
{
    // Get the AR Manager component
    ARCameraManager camera;
    ARFaceManager faceManager;
    ARPlaneManager planeManager;
    ARRaycastManager raycastManager;

    // Get the model controller

    // Get the debug message component
    ActionMessage message;
    bool currCamera = false;

    private void Awake()
    {
        camera = GetComponent<ARCameraManager>();
        faceManager = FindFirstObjectByType<ARFaceManager>();
        planeManager = FindFirstObjectByType<ARPlaneManager>();
        raycastManager = FindFirstObjectByType<ARRaycastManager>();

        message = FindFirstObjectByType<ActionMessage>();
    }

    // Change the camera facing direction
    public void ChangeCameraDirection()
    {
        message.SetMessage("Switched!" + "\nRequested CamPOS=" + camera.requestedFacingDirection + "\nCurr CamPos=" + camera.currentFacingDirection);
        if (currCamera)
        {
            // Disable user camera function
            faceManager.enabled = false;

            // Enable front camera function
            planeManager.enabled = true;
            raycastManager.enabled = true;


            // Switch to front camera
            currCamera = false;
            camera.requestedFacingDirection = CameraFacingDirection.World;
        }
        else
        {
            // Enable user camera function
            faceManager.enabled = true;

            // Disable front camera function
            planeManager.enabled = false;
            raycastManager.enabled = false;

            currCamera = true;
            camera.requestedFacingDirection = CameraFacingDirection.User;
        }
    }
}
