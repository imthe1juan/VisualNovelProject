using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour
{
    public Slider volumeSlider;
    public AudioSource audioSource;

    void Start()
    {
        // Assuming you have an AudioSource component attached to the same GameObject
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Set the slider's value to the current volume level
        volumeSlider.value = audioSource.volume;

        // Add a listener to the slider so that the volume changes when the slider is moved
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    void OnVolumeChanged(float volume)
    {
        // Update the volume of the audio source when the slider value changes
        audioSource.volume = volume;
    }
}
