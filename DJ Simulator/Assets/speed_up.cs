using UnityEngine;

public class speed_up : MonoBehaviour
{
    // Reference to the AudioSource whose pitch will be changed
    public AudioSource targetAudioSource;

    // The amount by which the pitch increases with each click
    public float pitchStep = 0.01f; // Adjust this value to set how much the pitch increases per click

    // The minimum and maximum pitch limits
    public float minPitch = 0.75f; // Set the minimum pitch limit
    public float maxPitch = 1.25f; // Set the maximum pitch limit

    void Start()
    {
        // Ensure the AudioSource is assigned
        if (targetAudioSource == null)
        {
            Debug.LogError("No target AudioSource assigned!");
        }
        
    }

    // This method is called when the GameObject the script is attached to is clicked
    void OnMouseDown()
    {
        // Check if the target audio source is assigned
        if (targetAudioSource != null)
        {
            // Increase the pitch by the defined step
            targetAudioSource.pitch += pitchStep;

            // Clamp the pitch between the minimum and maximum limits
            targetAudioSource.pitch = Mathf.Clamp(targetAudioSource.pitch, minPitch, maxPitch);

            // Optional: Log the current pitch to the console
            Debug.Log("Current Pitch: " + targetAudioSource.pitch);
        }
    }
}