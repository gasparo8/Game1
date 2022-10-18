using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        //added below to stop skeleton animation from falling
        rb = GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");

        //Die Animation
        animator.SetBool("isDead", true);

        //disable enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //added below to stop skeleton animation from falling
        rb.gravityScale = 0;
        rb.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
