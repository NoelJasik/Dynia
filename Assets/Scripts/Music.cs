using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Music : MonoBehaviour
{
      FMODUnity.StudioEventEmitter musicPlayer;
 private void Awake()
 {
     int numMusicPlayers = FindObjectsOfType<Music>().Length;
     if (numMusicPlayers != 1)
     {
         Destroy(gameObject);
     }
     // if more then one music player is in the scene
     //destroy ourselves
     else
     {
         DontDestroyOnLoad(gameObject);
     musicPlayer = GetComponent<FMODUnity.StudioEventEmitter>();
     }
    
 }
 void Update()
 {
    int musicNum = Mathf.Clamp(SceneManager.GetActiveScene().buildIndex, 0, 1);
    musicPlayer.SetParameter("Music", musicNum);
 }

}
