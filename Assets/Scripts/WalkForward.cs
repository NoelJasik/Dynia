using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkForward : MonoBehaviour
{
    public Vector3 moveSpeed;
    [SerializeField]
    float existanceTime;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    float jumpTime;

    float jumpTimer;

    float existanceTimer;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpTimer = 0.1f;
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
            transform.localScale = Vector3.zero;
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
        // jump
        jumpTimer -= Time.deltaTime;
        if (jumpTimer <= 0 && rb.velocity.y > -0.1f && rb.velocity.y < 0.1f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpTimer = jumpTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Obstacle")
        {
            moveSpeed = Vector3.zero;
            jumpForce = 0;
            rb.freezeRotation = false;
        }
    }
}
