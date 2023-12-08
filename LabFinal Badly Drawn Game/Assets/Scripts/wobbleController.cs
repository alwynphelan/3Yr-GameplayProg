using UnityEngine;

public class wobbleController : MonoBehaviour
{
    public float rotationSpeed = 50.0f; // Adjust the speed of rotation as needed
    public bool rotateRight = true; // Indicates initial direction

    void Update()
    {
        if (rotateRight)
        {
            this.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        else
        {
            this.transform.Rotate(-Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Change direction when reaching certain angle (e.g., 90 degrees)
        if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 25f)
        {
            rotateRight = !rotateRight;
        }
    }
}
