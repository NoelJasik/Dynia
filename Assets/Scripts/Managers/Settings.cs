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
            FMOD.Studio.VCA UI;
            FMOD.Studio.VCA musicBus;
    float volume = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.value = QualitySettings.GetQualityLevel();
        gameplayBus = FMODUnity.RuntimeManager.GetVCA("vca:/Gameplay");
        UI = FMODUnity.RuntimeManager.GetVCA("vca:/UI");
        musicBus = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        UI.getVolume(out float startVolume);
        volume = startVolume;
        volumeSlider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
        gameplayBus.setVolume(volume);
        UI.setVolume(volume);
        musicBus.setVolume(volume * 0.75f);
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
