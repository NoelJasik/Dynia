using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDriving : MonoBehaviour
{
    public Vector3 moveSpeed;
    [SerializeField]
    float existanceTime;

    float existanceTimer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.localScale = new Vector3(0, 0, 0);
        existanceTimer = existanceTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (existanceTimer > 0)
        {
            SpawnAnimation();
        }
        // destroy
        existanceTimer -= Time.deltaTime;
        if (existanceTimer <= 0)
        {
            DestroyAnimation();
        }
    }

    void SpawnAnimation()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one, 0.1f);
        if (transform.localScale.x > 0.9f && transform.localScale.y > 0.9f && transform.localScale.z > 0.9f)
        {
            transform.localScale = Vector3.one;
        }
        if (transform.localScale != Vector3.one)
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            Move();
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

    void Move()
    {
        // move forward
        if (moveSpeed != Vector3.zero)
        {
            rb.velocity = new Vector3(moveSpeed.x, rb.velocity.y, moveSpeed.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
                Debug.Log("collision");
                moveSpeed = Vector3.zero;
                rb.velocity = new Vector3(rb.velocity.x * 0.5f, rb.velocity.y, rb.velocity.z * 0.5f);
        }
    }
}
