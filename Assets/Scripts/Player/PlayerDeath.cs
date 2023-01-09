using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    DeathManager deathManager;

    public bool spawnInvincibility = false;

    [SerializeField]
    float invincibilityTime = 2f;

    float invincibilityTimer;

    [SerializeField]
    FMODUnity.EventReference tiltUp;
    [SerializeField]
    FMODUnity.EventReference tiltDown;
    bool canSoundPlay = true;
    float soundCooldown = 0;


    // Start is called before the first frame update
    void Start()
    {
        deathManager = FindObjectOfType<DeathManager>();
        deathManager.SetCheckpoint(transform.position);

    }

    public void startSpawnInvincibility()
    {
        spawnInvincibility = true;
        invincibilityTimer = invincibilityTime;
    }

    // Update is called once per frame
    void Update()
    {
        soundCooldown -= Time.deltaTime;
        if (spawnInvincibility)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                spawnInvincibility = false;
            }
            else
            {
                return;
            }
        }
        // If the player presses R, die
        if (Input.GetKeyDown(KeyCode.R))
        {
            deathManager.Die();
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
        if ((transform.rotation.eulerAngles.x > 140 && transform.rotation.eulerAngles.x < 300) || (transform.rotation.eulerAngles.x < -140 && transform.rotation.eulerAngles.x > -300))
        {
            Debug.Log("Player has died");
            deathManager.Die();
        }
        if (transform.rotation.eulerAngles.x > 10 && transform.rotation.eulerAngles.x < 300 && canSoundPlay && soundCooldown <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(tiltUp, transform.position);
            canSoundPlay = false;
            soundCooldown = 0.25f;

        }
        if (transform.rotation.eulerAngles.x < -10 && transform.rotation.eulerAngles.x > -300 && canSoundPlay && soundCooldown <= 0)
        {
            FMODUnity.RuntimeManager.PlayOneShot(tiltDown, transform.position);
            canSoundPlay = false;
            soundCooldown = 0.25f;

        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            canSoundPlay = true;
        }
        if(other.gameObject.tag == "End")
        {
            deathManager.Die();
        }
    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.layer == 6)
        {
            canSoundPlay = true;
        }
    }
}
