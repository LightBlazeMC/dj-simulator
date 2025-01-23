using UnityEngine;

public class speed_reset : MonoBehaviour
{
    // Reference to the AudioSource whose pitch will be changed
    public AudioSource targetAudioSource;

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
            targetAudioSource.pitch = 1;

            // Optional: Log the current pitch to the console
            Debug.Log("Current Pitch: " + targetAudioSource.pitch);
        }
    }
}