using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    DeathManager deathManager;

    public bool spawnInvincibility = false;

    [SerializeField]
    float invincibilityTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        deathManager = FindObjectOfType<DeathManager>();
        deathManager.SetCheckpoint(transform.position);

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnInvincibility)
        {
            invincibilityTime -= Time.deltaTime;
            if(invincibilityTime <= 0)
            {
                spawnInvincibility = false;
            } else
            {
                return;
            }
        }
        // If the player falls off the map, die
        if (transform.position.y < -10)
        {
            deathManager.Die();
        }
        // If the player falls over, die
        if ((transform.rotation.eulerAngles.z > 80 && transform.rotation.eulerAngles.z < 300) || (transform.rotation.eulerAngles.z < -80 && transform.rotation.eulerAngles.z > -300))
        {
            Debug.Log("Player has died");
            deathManager.Die();
        }
        if ((transform.rotation.eulerAngles.x > 100 && transform.rotation.eulerAngles.x < 300) || (transform.rotation.eulerAngles.x < -100 && transform.rotation.eulerAngles.x > -300))
        {
            Debug.Log("Player has died");
            deathManager.Die();
        }
    }
}
