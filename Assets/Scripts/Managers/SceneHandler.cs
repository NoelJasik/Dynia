using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    [SerializeField]
    float fadeTime = 1f;
    [SerializeField]

    GameObject startFadePanel;
    [SerializeField]
    GameObject endFadePanel;

    PauseManager pauseManager;

    // Start is called before the first frame update
    void Start()
    {
       startFadePanel.SetActive(true);        
       Invoke("hideScene", fadeTime);
       Time.timeScale = 1;
       pauseManager = FindObjectOfType<PauseManager>();
    }

    void hideScene()
    {
        startFadePanel.SetActive(false);
        pauseManager.canPause = true;
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(ChangeScene(sceneIndex));
    }

    public void LoadNextScene()
    {
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(ChangeScene(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    public IEnumerator ChangeScene(int sceneIndex)
    {
        Time.timeScale = 0;
        endFadePanel.SetActive(true);
        yield return new WaitForSecondsRealtime(fadeTime);
        SceneManager.LoadScene(sceneIndex);
    }
    
}
