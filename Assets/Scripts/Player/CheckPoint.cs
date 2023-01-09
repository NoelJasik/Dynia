using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    DeathManager deathManager;
    Animator anim;
    
    [SerializeField]
    Transform checkpointSpawnPoint;
    [SerializeField]
    bool startHere;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        deathManager = FindObjectOfType<DeathManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(startHere)
        {
            deathManager.SetCheckpoint(checkpointSpawnPoint.position);
            deathManager.Die();
            startHere = false;
        }
        if(checkpointSpawnPoint.position != deathManager.respawnPoint)
        {
            anim.Play("Unused");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            deathManager.SetCheckpoint(checkpointSpawnPoint.position);
            anim.Play("Reached");
        }
    }
}
