using UnityEngine;

public class LookAtCam : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        // Find the camera in the scene (tag your main camera as "MainCamera")
        cameraTransform = Camera.main.transform;
    }

    void LateUpdate()
    {
        // Make the object face the camera
        transform.LookAt(transform.position + cameraTransform.forward);
        transform.Rotate(90, 0, 180); // Adjust these values based on your plane's setup
    }
}
