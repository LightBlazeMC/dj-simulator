using UnityEngine;

public class discoball : MonoBehaviour
{
    // Define the rotation speed for each axis
    public Vector3 rotationSpeed = new Vector3(0, 45, 0); // Change these values to adjust rotation speed

    void Update()
    {
        // Apply rotation over time
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}