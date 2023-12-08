using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform player; // Reference to the player's transform

    void Update()
    {
        // Check if player reference is set and follow the player's position
        if (player != null)
        {
            Vector3 playerPosition = player.position;
            playerPosition.z = transform.position.z; // Maintain camera's Z position
            transform.position = playerPosition;
        }
    }
}
