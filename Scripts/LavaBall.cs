using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaBall : MonoBehaviour
{

    private Rigidbody2D lavaBall;
    public float speed = 5f;
    public float maxHeight = 5f; // The maximum height the lava ball should reach before returning back down
    private bool goingUp = true;
    public Player player;
    private int damage = 35;
    private Vector2 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        lavaBall = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Store the initial position at the start

        // Initialize the player variable.
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }

    
    private void FixedUpdate()
    {

        if (goingUp)
        {
            // Move the lava ball up using physics forces
            lavaBall.velocity = new Vector2(lavaBall.velocity.x, speed);

            // Check if the lava ball has reached the maximum height
            if (transform.position.y >= maxHeight)
            {
                // Change the direction (going down)
                goingUp = false;

                // Flip the sprite vertically
                Vector3 scale = transform.localScale;
                scale.y = -1f;
                transform.localScale = scale;
            }
        }

        else
        {
            // Move the lava ball down using physics forces
            lavaBall.velocity = new Vector2(lavaBall.velocity.x, -speed);

            // Check if the lava ball has returned back to the original position
            if (transform.position.y <= initialPosition.y)
            {
                // Reset the position to the initial starting point
                transform.position = initialPosition;

                // Change the direction (going up)
                goingUp = true;

                // Flip the sprite back to its original orientation
                Vector3 scale = transform.localScale;
                scale.y = 1f;
                transform.localScale = scale;
            }
        }
    }


        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (player != null && collision.gameObject.CompareTag("Player"))
            {
                player.TakeDamage(damage);
                Debug.Log("Player took DAMAGE");
                Destroy(gameObject);
            }
        }
    }
