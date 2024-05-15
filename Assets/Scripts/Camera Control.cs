using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Camera[] cameras; // Array of cameras to switch between
    public Camera ControlCamera = null;
    public Canvas VRCanvas, MainCanvas;
    private int currentCameraIndex = 0;

    void Start()
    {
        // Disable all cameras except the first one
        for (int i = 1; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Check for the "V" key press
        if (Input.GetButtonDown("CameraSwitch"))
        {
            // Disable the current camera
            cameras[currentCameraIndex].gameObject.SetActive(false);

            // Increment the camera index or reset to 0 if it exceeds the array length
            currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

            // Enable the new current camera
            cameras[currentCameraIndex].gameObject.SetActive(true);
        }

        if (cameras[0].isActiveAndEnabled) // VR Camera
        {
            MainCanvas.enabled = false;
            VRCanvas.enabled = true;
            ControlCamera.gameObject.SetActive(true);
        }
        else
        {
            MainCanvas.enabled = true;
            VRCanvas.enabled = false;
            ControlCamera.gameObject.SetActive(false);
        }
    }
}
