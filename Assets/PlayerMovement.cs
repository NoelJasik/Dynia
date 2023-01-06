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

    // Torque applied to the car's wheels
    [SerializeField]
    float torque = 5.0f;

    // Reference to the car's rigidbody component
    Rigidbody rb;

    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input from the horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");

        // Apply torque to the wheels based on the input
        rb.AddTorque(transform.up * torque * horizontalInput);

        // Get input from the vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the current speed of the car
        float currentSpeed = rb.velocity.magnitude;

        // If the current speed is less than the maximum speed, apply a force in the forward direction based on the input
        if (currentSpeed < maxSpeed)
        {
            rb.AddForce(transform.forward * speed * verticalInput);
        }
    }
}