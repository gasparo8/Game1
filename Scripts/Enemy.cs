using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;
    private Rigidbody2D rb;

    public DetectionZone attackZone;

    private Player player;
    private Vector2 playerPosition;

    public bool _hasTarget = false;
    public bool enemyIsDead = false;

    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
           
            if (player != null && playerPosition.x > this.transform.position.x)
            {
                this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }

            else if (player != null && playerPosition.x < this.transform.position.x)
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            
            _hasTarget = value;
            animator.SetBool("hasTarget", value);
        }
    }
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the player variable.
        if (GameObject.FindWithTag("Player") != null)
        {
            player = GameObject.FindWithTag("Player").GetComponent<Player>();
        }
    }


    // Initialize the playerPosition variable.
    private void FixedUpdate()
    {
        playerPosition = player.transform.position;
    }


    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;      
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

        //Set enemyIsDead to true
        enemyIsDead = true;

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
