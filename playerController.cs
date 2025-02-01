using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    // private RigidBody rb;
    private float speed = 10f;
    private float jumpForce = 5f; // Force applied when the player jumps
    private float gravity = -9.8f; // Gravity to pull the player down
    private bool isGrounded = true; // Check if the player is on the ground

    private Vector3 velocity;

    // Start is called before the first frame update
    // void Start(){
    //     rb = GetComponent<RigidBody>();
    // }

    // Update is called once per frame
    void Update(){
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        // transform.position += direction + speed * time.DeltaTime;
        // rb.AddForce(direction * speed);
        // transform.position += direction + speed * Time.DeltaTime;
        transform.position += direction * speed * Time.deltaTime;


        // chat code
        // Jump logic (only allow jumping if grounded)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space)){
            velocity.y = jumpForce; // Apply jump force to the y-axis
            isGrounded = false; // Player is no longer on the ground once they jump
        }

        // Apply gravity (affects the vertical movement)
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement (gravity and jump)
        transform.position += velocity * Time.deltaTime;

        // Check if player is grounded (you can use raycasting or other methods)
        if (transform.position.y < .5f){
            // If the player's y-position is at or below ground level
            isGrounded = true; // The player is back on the ground
            velocity.y = .5f; // Reset vertical velocity once they land
        }
    }
}