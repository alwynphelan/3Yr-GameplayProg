using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float zoomSpeed = 1.0f; // Speed of the zooming
    public float minZoom = .7f; // Minimum zoom level
    public float maxZoom = 2.0f; // Maximum zoom level

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Check if scroll input is detected
        if (scroll != 0.0f)
        {
            // Change the camera's orthographic size based on the scroll input
            Camera.main.orthographicSize = Mathf.Clamp(
                Camera.main.orthographicSize - scroll * zoomSpeed,
                minZoom,
                maxZoom
            );
        }
    }
}
