using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D arrow;
    private Player player;
    private int damage = 35;


    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<Rigidbody2D>();

        // Initialize the player variable.
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.TakeDamage(damage);
            Debug.Log("Player took DAMAGE");
            Destroy(gameObject);
        }
    }
}
