using UnityEngine;

public class deck_platter : MonoBehaviour
{
    // Reference to the AudioSource on another object
    public AudioSource targetAudioSource;

    // Rotation speed
    public float rotationSpeed = 50f;

    void Update()
    {
        // Check if the AudioSource is playing
        if (targetAudioSource != null && targetAudioSource.isPlaying)
        {
            // Apply continuous rotation
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }
}
