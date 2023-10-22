using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXSettings : MonoBehaviour
{
    public Slider sfxSlider;
    public AudioSource[] sfxAudioSources;

    void Start()
    {
        // Assuming you have a Slider component attached to the same GameObject
        if (sfxSlider == null)
        {
            sfxSlider = GetComponent<Slider>();
        }

        // Add a listener to the slider so that the SFX volumes change when the slider is moved
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
    }

    void OnSFXVolumeChanged(float volume)
    {
        // Update the volume of all SFX audio sources when the slider value changes
        foreach (var audioSource in sfxAudioSources)
        {
            audioSource.volume = volume;
        }
    }
}
