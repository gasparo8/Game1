using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    public AudioClip[] swordSwingClips;
    private AudioSource audioSource;
 
    public Player player;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            SwordSwingAudio();
        }
    }

    void Attack()
    {
        {
          if (player.isGrounded == true)
            {
                // Play an attack animation
                animator.SetTrigger("Attack");
            }
        }

        // Detect enemies in range of attack. Center Point is attackPoint.position, radius is attackRange, and filters out layers
        // The Collider2D[] hitEnemies stores all enemies hit
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Damage enemies
        foreach (Collider2D enemyCollider in hitEnemies)
        {
            // Check if the collider's GameObject has an Enemy or Demon component
            Enemy enemy = enemyCollider.GetComponent<Enemy>();
            Demon demon = enemyCollider.GetComponent<Demon>();

            if (enemy != null && player.isGrounded == true)
            {
                // This is a general enemy (not a demon)
                enemy.TakeDamage(attackDamage);
            }
            else if (demon != null && player.isGrounded == true)
            {
                // This is a demon-specific behavior
                demon.TakeDamage(attackDamage);
            }
        }
    }


    void SwordSwingAudio()
    {
        if (player.isGrounded == true)
        {
            // Randomly select one of the sword swing clips.
            int randomIndex = Random.Range(0, swordSwingClips.Length);

            // Play the selected sword swing clip.
            audioSource.clip = swordSwingClips[randomIndex];
            audioSource.Play();
        }
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // Allows us to visualize attack sphere
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

    