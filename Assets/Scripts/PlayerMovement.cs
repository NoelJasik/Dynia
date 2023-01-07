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
    GameObject[] movementEffect;

    // Angle at which the car starts to tip over
    [SerializeField]
    float tippingAngle = 45.0f;

    // Torque applied to stabilize the car
    [SerializeField]
    float stabilizationForce = 1000.0f;

    // Reference to the car's rigidbody component
    Rigidbody rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.y > -0.5f && rb.velocity.y < 0.5f)
        {
            Movement();
            //Stabilize();
        }
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

        // If the player is moving forward, spawn a particle effect
        foreach (GameObject particle in movementEffect)
        {
            particle.SetActive(currentSpeed > 1.0f);
        }

        // If the current speed is less than the maximum speed, apply a force in the forward direction based on the input
        if (currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * speed * verticalInput);
        }

    }

    // Calculates and applies the torque needed to keep the car upright// Calculates and applies the torque needed to keep the car upright
    void Stabilize()
    {
        // Calculate the torque needed to correct the car's rotation
        float torque = 0;
        if ((transform.rotation.eulerAngles.z > tippingAngle && transform.rotation.eulerAngles.z < 300))
        {
            torque = -stabilizationForce; // Add torque in the opposite direction that the car is falling over
        }
        else if ((transform.rotation.eulerAngles.z < -tippingAngle && transform.rotation.eulerAngles.z > -300))
        {
            torque = stabilizationForce; // Add torque in the opposite direction that the car is falling over
        } else 
        {
            torque = 0;
        }

        // Apply the torque to the rigidbody
        rb.AddTorque(new Vector3(0, 0, torque));

    }


}


