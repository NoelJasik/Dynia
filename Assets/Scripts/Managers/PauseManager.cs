using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    public bool canPause = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                // FMOD.Studio.EventInstance pauseEvent = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause");
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);

            }
        }
    }
}
