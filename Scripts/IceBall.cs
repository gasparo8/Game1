using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{
    [HideInInspector]
    public float speed;
    private Rigidbody2D iceBall;
    private Player player;
    private int damage = 35;


    // Start is called before the first frame update
    void Start()
    {
        iceBall = GetComponent<Rigidbody2D>();

        // Initialize the player variable.
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        speed = -2f;

        //applying speed to x and leaving the y alone by keeping it at iceBall.velocity.y
        iceBall.velocity = new Vector2(speed, iceBall.velocity.y);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("LeftCollector"))
        {
            Destroy(gameObject);
        }
    }
}