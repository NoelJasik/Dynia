using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
                 FMODUnity.RuntimeManager.MuteAllEvents(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
                 FMODUnity.RuntimeManager.MuteAllEvents(false);

            }
        }
    }
}
