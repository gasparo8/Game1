using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 4f;

    [SerializeField]
    private float jumpForce = 11f;

    public float movementX;

    [SerializeField]
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;

    private string WALK_ANIMATION = "Walk";

    private bool isGrounded;
    private string GROUND_TAG = "Ground";

    public float leftBound = -9.85f;
    public float rightBound = 13.8f;

    public int maxHealth = 100;

    public int currentHealth;

    private void Awake()
    {

        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeyboard()
    {

        // Keeps player inbounds
        if (transform.position.x < leftBound)
        {
            transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x > rightBound)
        {
            transform.position = new Vector3(rightBound, transform.position.y, transform.position.z);
        }

        //allows player to walk
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        //walking right
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        else if (movementX < 0)
        {
            //walking left
            anim.SetBool(WALK_ANIMATION, true);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("IsJumping", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            anim.SetBool("IsJumping", false);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("isHit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        {
            Debug.Log("Player Died");
            anim.SetBool("isDead", true);
            DisablePlayer();
        }
    }

    void DisablePlayer()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //added below to stop player from falling
        myBody.gravityScale = 0;
        myBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}
      