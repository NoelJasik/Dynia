using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    SceneHandler sceneHandler;

    // Start is called before the first frame update
    void Start()
    {
      sceneHandler = FindObjectOfType<SceneHandler>();   
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sceneHandler.LoadNextScene();
        }
    }
}
