using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    
    [SerializeField]
    GameObject playerDeathEffect;
    
    [SerializeField]
    TopDownCamera topDownCamera;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
        {
            Die();
        }
        Debug.Log(transform.rotation.z);
        if(transform.rotation.z > 0.5 || transform.rotation.z < -0.5)
        {
            Debug.Log("Player has died");
            Die();
        }
    }

    // Die function
    void Die()
    {
        GameObject deadBody = Instantiate(playerDeathEffect, transform.position, transform.rotation);
        topDownCamera.player = deadBody.transform;
        Destroy(gameObject);
    }
}
