using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpeedOnStart : MonoBehaviour
{
    [SerializeField]
    float minSpeed = -10.0f;
    [SerializeField]
    float maxSpeed = 10.0f;
    [SerializeField]
    float existanceTime = 5.0f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // add a random force to the rigidbody
        rb.AddForce(new Vector3(Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed), Random.Range(minSpeed, maxSpeed)), ForceMode.Impulse);
    }

    void FixedUpdate()
    {
        // destroy after a certain time
        existanceTime -= Time.deltaTime;
        if (existanceTime <= 0)
        {
            DestroyAnimation();
        }
    }

    void DestroyAnimation()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 0.1f);
        if (transform.localScale.x < 0.1f && transform.localScale.y < 0.1f && transform.localScale.z < 0.1f)
        {
            transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
            Destroy(gameObject);
        }
    }

}
