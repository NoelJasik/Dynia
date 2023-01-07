using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    [SerializeField]
    GameObject playerDeathEffect;

    [SerializeField]
    TopDownCamera topDownCamera;
    public Vector3 respawnPoint;
    [SerializeField]
    float respawnTime;
    [SerializeField]
    GameObject respawnEffect;
    [SerializeField]
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCheckpoint(Vector3 checkpoint)
    {
        respawnPoint = checkpoint;
    }
    // Die function
    public void Die()
    {
        if(player.activeSelf == false)
        {
            return;
        }
        GameObject deadBody = Instantiate(playerDeathEffect, player.transform.position, player.transform.rotation);
        topDownCamera.player = deadBody.transform;
        player.SetActive(false);
        respawnEffect.SetActive(true);
        Invoke("Respawn", respawnTime);
    }

    void Respawn()
    {
        player.transform.position = respawnPoint;
        player.SetActive(true);
        topDownCamera.player = player.transform;
        Invoke("HideRespawnEffect", respawnTime);
    }

    void HideRespawnEffect()
    {
        respawnEffect.SetActive(false);
    }
}
