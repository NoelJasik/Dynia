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

FMOD.Studio.Bus masterBus;
float volume = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        resolutionDropdown.value = QualitySettings.GetQualityLevel();
        masterBus = FMODUnity.RuntimeManager.GetBus("bus:/Gameplay");
        volume = (float)masterBus.getVolume(out volume);
        volumeSlider.value = volume;
    }

    // Update is called once per frame
    void Update()
    {
                masterBus.setVolume(volume);
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
