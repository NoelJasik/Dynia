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
        // If the player falls off the map, die
        if(transform.position.y < -10)
        {
            Die();
        }
        // If the player falls over, die
        if((transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 300) || (transform.rotation.eulerAngles.z < -80 && transform.rotation.eulerAngles.z > -300))
        {
            Debug.Log("Player has died");
            Die();
        }
        if((transform.rotation.eulerAngles.x > 100 && transform.rotation.eulerAngles.x < 300) || (transform.rotation.eulerAngles.x < -100 && transform.rotation.eulerAngles.x > -300))
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
