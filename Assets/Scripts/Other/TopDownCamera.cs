using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCamera : MonoBehaviour
{

    // Position of player
    public Transform player;

    // Offset of camera from player
    [SerializeField]
    Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        // Set the camera's position to the player's position plus the offset 
        transform.position = player.position + offset;        
        
    }
}
