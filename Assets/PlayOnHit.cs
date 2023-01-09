using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnHit : MonoBehaviour
{
    [SerializeField]
    FMODUnity.EventReference hitSound;
    [SerializeField]
    List<string> tags;
    [SerializeField]
    float minSpeed = 2f;
[SerializeField]
    float playCooldown = 0.25f;

    float playCooldownTimer;

    // Start is called before the first frame update
    void Start()
    {
playCooldownTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
playCooldownTimer -= Time.deltaTime;
    }

    void OnCollisionEnter(Collision other)
    {
        foreach (string tag in tags)
        {
            if (other.gameObject.GetComponent<Rigidbody>() != null)
            {
                Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
                Rigidbody rbObject = GetComponent<Rigidbody>();
                if(((rb.velocity.magnitude < minSpeed && rb.velocity.magnitude > 0) || (rb.velocity.magnitude > -minSpeed && rb.velocity.magnitude < 0)) && ((rbObject.velocity.magnitude < minSpeed && rbObject.velocity.magnitude > 0) || (rbObject.velocity.magnitude > -minSpeed && rbObject.velocity.magnitude < 0)))
                {
                    break;
                }
            }
            if (other.gameObject.tag == tag && playCooldownTimer <= 0)
            {
                FMODUnity.RuntimeManager.PlayOneShot(hitSound, other.transform.position);
            playCooldownTimer = playCooldown;
            }
        }
    }
}
