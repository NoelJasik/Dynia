using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAttack : MonoBehaviour
{

    [SerializeField]
    float attackForce = 100f;
    Rigidbody rb;

    bool attacked = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !attacked)
        {
            Vector3 direction = other.transform.position - transform.position;
            direction.Normalize();
            rb.AddForce(direction * attackForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * attackForce / 10, ForceMode.Impulse);
            attacked = true;
        }
    }
}
