using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed of the player

    private Vector3 movement;

    void Update()
    {
        // Get input for movement
        movement.x = Input.GetAxisRaw("Horizontal"); // A, D, or Left, Right
        movement.z = Input.GetAxisRaw("Vertical");   // W, S, or Up, Down

        // Normalize movement vector to prevent faster diagonal movement
        movement = movement.normalized;

        // Apply movement to the player object
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);
    }
}
