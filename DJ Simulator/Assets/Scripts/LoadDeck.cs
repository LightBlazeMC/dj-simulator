using UnityEngine;
using System.Collections.Generic;  // Needed to use List

public class LoadDeck : MonoBehaviour
{
    public AudioSource audioSource;         // Reference to the AudioSource component
    public List<AudioClip> audioClips;      // List to hold multiple audio clips

    private int currentClipIndex = 0;       // Index to track which clip to play

    public held_track scriptA;
    public deck_btn scriptB;

    void Update()
    {
        currentClipIndex = scriptA.TrackID;
    }

    public void PlayDeck()
    {
        // Check if there are any audio clips assigned
        if (audioClips.Count > 0)
        {
            currentClipIndex = scriptA.TrackID;
            scriptB.hasPlayed = false;
            // Play the first clip
            PlayClip(currentClipIndex);
        }
        else
        {
            Debug.LogWarning("No audio clips assigned in the list!");
        }
    }

    // Method to play a specific clip based on index
    public void PlayClip(int index)
    {
        if (index >= 0 && index < audioClips.Count)
        {
            currentClipIndex = scriptA.TrackID;
            audioSource.clip = audioClips[index];
            //audioSource.Play();
            Debug.Log("current clip index: " + currentClipIndex);
        }
        else
        {
            Debug.LogError("Invalid clip index: " + index);
        }
    }

    // Method to add a new AudioClip to the list at runtime
    public void AddClip(AudioClip newClip)
    {
        if (newClip != null)
        {
            audioClips.Add(newClip);
            Debug.Log("Added new clip: " + newClip.name);
        }
        else
        {
            Debug.LogWarning("Cannot add null AudioClip!");
        }
    }
}