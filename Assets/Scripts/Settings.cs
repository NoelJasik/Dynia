using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown resolutionDropdown;

[SerializeField]
Slider volumeSlider;

FMOD.Studio.VCA gameplayBus;
float volume = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.value = QualitySettings.GetQualityLevel();
        gameplayBus = FMODUnity.RuntimeManager.GetVCA("vca:/Gameplay");
        volumeSlider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
                gameplayBus.setVolume(volume);
    }

    public void SetQuality()
    {
        QualitySettings.SetQualityLevel(resolutionDropdown.value);
    }

    public void SetVolume()
    {
        volume = volumeSlider.value;
    }
}
