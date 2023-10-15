using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private PlayerCombat playerCombat;

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
    public bool isGrounded;
    private string GROUND_TAG = "Ground";

    public float leftBound = -9.85f;
    public float rightBound = 13.8f;

    public int maxHealth = 100;
    public int currentHealth;

    private Vector3 respawnPoint;
    public GameObject fallDetector;

    public Enemy enemy;

    public HealthBar healthBar;

    public CameraShake cameraShake;

    public AudioClip [] playerHitClips;
    private AudioSource audioSource;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerCombat = GetComponent<PlayerCombat>();
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        respawnPoint = transform.position;
        healthBar.SetMaxHealth(maxHealth);
        audioSource = GetComponent<AudioSource>();
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


    private bool IsEnemyDead()
    {
        return enemy != null && enemy.enemyIsDead;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Fall Detector")
        {
            transform.position = respawnPoint;
        }


        else if (collision.tag == "Next Level")
        {
            if (enemy == null || IsEnemyDead())
            {
                // If the enemy is dead, advance to the next level
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                respawnPoint = transform.position;
            }

            else
            {
                Debug.Log("Enemy still alive!");
                return;

            }
        }

        else if (collision.tag == "Previous Level")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            respawnPoint = transform.position;
        }
    }

     
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        anim.SetTrigger("isHit");
        StartCoroutine(cameraShake.Shake(.15f, .2f));
        playerHitSound();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void playerHitSound()
    {
        if (playerHitClips.Length > 0)
        {
            // Randomly select one of the player hit clips.
            int randomIndex = Random.Range(0, playerHitClips.Length);

            // Play the selected player hit clip using the AudioSource
            audioSource.clip = playerHitClips[randomIndex];
            audioSource.Play();
        }
    }

    void Die()
    {
        Debug.Log("Player Died");

        if (!isGrounded)
        {
            StartCoroutine(WaitForGroundAndDie());
        }
        else
        {
            PlayDeathAnimation();
        }
    }

    IEnumerator WaitForGroundAndDie()
    {
        while (!isGrounded)
        {
            yield return null;
        }

        PlayDeathAnimation();
    }

    void PlayDeathAnimation()
    {
        anim.SetBool("isDead", true);
        DisablePlayer();
    }


    void DisablePlayer()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;

        //disable PlayerCombat script
        playerCombat.enabled = false;

        //added below to stop player from falling
        myBody.gravityScale = 0;
        myBody.constraints = RigidbodyConstraints2D.FreezePositionX;
    }
}

/* https://tinyurl.com/ykc3gb4p Song 1*/