using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedOnStart : MonoBehaviour
{
    [SerializeField]
    float minSpeed = 10.0f;
    [SerializeField]
    float maxSpeed = 20.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed));
    }

}
