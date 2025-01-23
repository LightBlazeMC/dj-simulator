using UnityEngine;

public class deck_btn : MonoBehaviour
{
    // Reference to the AudioSource on another object
    public AudioSource targetAudioSource;

    // Flag to check if the audio has been played at least once
    public bool hasPlayed = false;

    public GameObject targetObject;
    public bool isPlaying = false;

    //public held_track scriptA;

    void Start()
    {
        // Ensure the audio doesn't play on start
        if (targetAudioSource != null)
        {
            targetAudioSource.playOnAwake = false; // Redundant safety check
            targetAudioSource.Stop(); // Ensure the audio is stopped at the start
        }
    }

    void Update()
    {
        // Check for input or interaction (e.g., mouse click or key press)
        if (Input.GetMouseButtonDown(0)) // Left mouse button click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.gameObject == targetObject)
                {
                    if (targetAudioSource != null)
                    {
                        // If the audio hasn't played yet, play it for the first time
                        if (!hasPlayed)
                        {
                            targetAudioSource.Play();
                            hasPlayed = true; // Mark as played
                            isPlaying = true;
                        }
                        // If the audio is currently playing, pause it
                        else if (targetAudioSource.isPlaying)
                        {
                            targetAudioSource.Pause();
                            isPlaying = false;
                        }
                        // If the audio is paused, resume playback
                        else if (!targetAudioSource.isPlaying && targetAudioSource.time > 0f)
                        {
                            targetAudioSource.UnPause();
                            isPlaying = true;
                        }
                    }

                }
            }
        }

        Debug.Log("isPlaying: " + isPlaying);
    }
}
