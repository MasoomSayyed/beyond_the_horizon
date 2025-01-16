using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private GameObject soundSlider, soundEffectsSlider;
    private Slider volumeSlider, volumeEffectsSlider;
    private AudioSource[] audioSources;
    void Start()
    {
        soundSlider = GameObject.FindGameObjectWithTag("SoundSlider");
        soundEffectsSlider = GameObject.FindGameObjectWithTag("SoundEffectsSlider");
        if (soundSlider != null)
        {
            volumeSlider = soundSlider.GetComponent<Slider>();
            volumeEffectsSlider = soundEffectsSlider.GetComponent<Slider>();
            // Initializing the audio sources with the sliders
            audioSources = GameObject.FindGameObjectWithTag("GameController").GetComponents<AudioSource>();
            volumeSlider.value = audioSources[0].volume / 2;
            volumeEffectsSlider.value = audioSources[1].volume / 2;
            // Changing the volume
            volumeSlider.onValueChanged.AddListener((value) => SetMusicVolume("Sound", value));
            volumeEffectsSlider.onValueChanged.AddListener((value) => SetMusicVolume("SoundEffects", value));
        }
        else
        {
            Debug.Log("Sound Slider Not Found");
        }
    }

    public void SetMusicVolume(string musicType, float volume)
    {
        if (musicType == "Sound")
        {
            audioSources[0].volume = volume;
        }
        else
        {
            audioSources[1].volume = volume;
            GameManager gameManager = FindFirstObjectByType<GameManager>();
            if (gameManager != null)
            {
                gameManager.soundEffectsVolume = volume;
                Debug.Log(gameManager.soundEffectsVolume);
            }
        }
    }
}