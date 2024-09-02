using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightVFX : MonoBehaviour
{
    public Light lightToChange; // Reference to the Light component
    public float colorMultiplier = 22.0f; // Multiplier to adjust color intensity
    public AudioSource audioSource;
    private float[] samples = new float[64]; // Array to hold audio spectrum data
    public float lightColor;    //var to change color as time goes

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (audioSource.isPlaying)
        {
            audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular); // Get audio spectrum data
            float intensity = GetAverage(samples) * colorMultiplier; // Calculate intensity based on spectrum data
            lightColor = 0;
            Color newColor = new Color(intensity, lightColor, intensity);
            lightToChange.color = newColor;
        }
    }

    // Calculate the average of the spectrum data
    private float GetAverage(float[] data)
    {
        float sum = 0;
        for (int i = 0; i < data.Length; i++)
        {
            sum += data[i];
        }
        return sum / data.Length;
    }
}
