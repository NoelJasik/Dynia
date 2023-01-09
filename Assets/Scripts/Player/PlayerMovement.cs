using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed of the car in meters per second
    [SerializeField]
    float speed = 10.0f;

    // Maximum speed of the car in meters per second
    [SerializeField]
    float maxSpeed = 20.0f;

    // Rotation speed of the car in degrees per second
    [SerializeField]
    float rotationSpeed = 90.0f;

    [SerializeField]
    ParticleSystem[] movementEffect;

    [SerializeField]
    GameObject soundEffectForMovement;

    bool isTouchingGround = false;

    // Refrence the animator
    Animator anim;

    // Reference to the car's rigidbody component
    Rigidbody rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
        // Get the animator component
        anim = GetComponent<Animator>();
                    anim.Play("WheelsRide");
    }

    void FixedUpdate()
    {
        if (rb.velocity.y > -2f && rb.velocity.y < 2f)
        {
            Movement();
        }
        else
        {
            AirMovement();
        }
        if(rb.velocity.magnitude > 0.1f || rb.velocity.magnitude < -0.1f)
        {
            anim.speed = rb.velocity.magnitude / maxSpeed;
        } else
        {
            anim.speed = 0;
        }
        if (rb.velocity.y > 5f || rb.velocity.y < -5)
        {
            foreach (ParticleSystem particle in movementEffect)
            {
                if (particle.isPlaying)
                {
                    particle.Stop();
                    soundEffectForMovement.SetActive(false);
                }
            }
        }
    }

    void AirMovement()
    {
        float horiztontalInput = Input.GetAxis("Horizontal");
       // float verticalInput = Input.GetAxis("Vertical");

        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationSpeed * horiztontalInput * Time.deltaTime * 0.5f, 0));
    }

    void Movement()
    {


        // Get input from the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the current speed of the car
        float currentSpeed = rb.velocity.magnitude;

        // Rotate the car based on the speed and input
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, rotationSpeed * horizontalInput * Time.deltaTime * currentSpeed / maxSpeed, 0));

        // Get input from the vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        // If the current speed is less than the maximum speed, apply a force in the forward direction based on the input
        if (currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * speed * verticalInput);
        }


        // If the player is moving forward, spawn a particle effect
        foreach (ParticleSystem particle in movementEffect)
        {
            if ((currentSpeed > 1.0f || currentSpeed < -1.0f || verticalInput != 0) && rb.velocity.y < 5f && rb.velocity.y > -5f)
            {
                if (!particle.isPlaying)
                {
                    particle.Play();
                    soundEffectForMovement.SetActive(true);
                }
            }
            else
            {
                if (particle.isPlaying)
                {
                    particle.Stop();
                    soundEffectForMovement.SetActive(false);
                }
            }
        }

    }

    void OnCollisionEnter(Collision other)
    {
     isTouchingGround = true;   
    }
    void OnCollisionStay(Collision other)
    {
        isTouchingGround = true;
    }
    void OnCollisionExit(Collision other)
    {
        isTouchingGround = false;
    }

}




